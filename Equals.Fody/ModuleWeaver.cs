using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Fody.Metaprogramming
{
    public class ModuleWeaver : BaseModuleWeaver
    {
        public override void Execute()
        {
            foreach (var definitionType in ModuleDefinition.Types.Where(x => x.Properties.Any()))
            {
                var equals =
                    new MethodDefinition(
                        nameof(object.Equals),
                        MethodAttributes.Public
                        | MethodAttributes.HideBySig
                        | MethodAttributes.Virtual,
                        ModuleDefinition.TypeSystem.Boolean)
                    {
                        Body =
                        {
                            MaxStackSize = 2,
                            InitLocals = true
                        }
                    };

                // Init arguments.
                var argumentObj = new ParameterDefinition("other", ParameterAttributes.None, ModuleDefinition.TypeSystem.Object);
                equals.Parameters.Add(argumentObj);

                equals.Body.Variables.Add(new VariableDefinition(definitionType));
                equals.Body.Variables.Add(new VariableDefinition(ModuleDefinition.TypeSystem.Boolean));
                equals.Body.Variables.Add(new VariableDefinition(ModuleDefinition.TypeSystem.Int32));
                equals.Body.Variables.Add(new VariableDefinition(ModuleDefinition.TypeSystem.Boolean));

                // Labels for goto.
                var labelReturnFalse = Instruction.Create(OpCodes.Nop);

                var processor = equals.Body.GetILProcessor();

                // Foo foo = other as Foo;
                processor.Append(Instruction.Create(OpCodes.Ldarg_1));
                processor.Append(Instruction.Create(OpCodes.Isinst, definitionType));
                processor.Append(Instruction.Create(OpCodes.Stloc_0));

                // if (foo != null)
                processor.Append(Instruction.Create(OpCodes.Ldloc_0));
                processor.Append(Instruction.Create(OpCodes.Ldnull));
                processor.Append(Instruction.Create(OpCodes.Cgt_Un));
                processor.Append(Instruction.Create(OpCodes.Stloc_1));
                processor.Append(Instruction.Create(OpCodes.Ldloc_1));
                processor.Append(Instruction.Create(OpCodes.Brfalse_S, labelReturnFalse));

                // return Identify.Equals(foo.Identify);
                var property = definitionType.Properties.First();
                processor.Append(Instruction.Create(OpCodes.Ldarg_0));
                processor.Append(Instruction.Create(OpCodes.Call, property.GetMethod));
                processor.Append(Instruction.Create(OpCodes.Stloc_2));
                processor.Append(Instruction.Create(OpCodes.Ldloca_S, equals.Body.Variables[2]));
                processor.Append(Instruction.Create(OpCodes.Ldloc_0));
                processor.Append(Instruction.Create(OpCodes.Callvirt, property.GetMethod));

                var intDefinition = ModuleDefinition.TypeSystem.Int32.Resolve();
                var equalsByInt = intDefinition
                    .Methods
                    .Single(x =>
                        x.Name == nameof(int.Equals)
                        && x.Parameters.Count == 1
                        && x.Parameters.Single().ParameterType.FullName == intDefinition.FullName);
                processor.Append(Instruction.Create(OpCodes.Call, ModuleDefinition.ImportReference(equalsByInt)));
                processor.Append(Instruction.Create(OpCodes.Ret));


                // return false;
                processor.Append(labelReturnFalse);
                processor.Append(Instruction.Create(OpCodes.Ldc_I4_0));
                processor.Append(Instruction.Create(OpCodes.Ret));


                definitionType.Methods.Add(equals);
            }
        }

        public override IEnumerable<string> GetAssembliesForScanning()
        {
            yield return "netstandard";
        }
    }
}
