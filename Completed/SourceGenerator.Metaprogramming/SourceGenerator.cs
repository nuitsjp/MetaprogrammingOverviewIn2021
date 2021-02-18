using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerator.Metaprogramming
{
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
#if DEBUG
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                // コメントアウトを外すと、ビルドのたびにビルドプロセスにアタッチを求められるため通常はコメントアウトしておく
                //System.Diagnostics.Debugger.Launch();
            }
#endif

            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            try
            {
                var receiver = context.SyntaxReceiver as SyntaxReceiver;
                if (receiver == null) return;

                foreach (var targetType in receiver.Targets)
                {
                    var typeSymbol = context.Compilation.GetSemanticModel(targetType.SyntaxTree).GetDeclaredSymbol(targetType);
                    if (typeSymbol == null) throw new Exception("can not get typeSymbol.");

                    var identifiers =
                        targetType.Members
                            .Where(x => x
                                .AttributeLists
                                .SelectMany(attribute => attribute.Attributes)
                                .Any(attribute => attribute.Name.ToString() is "Identifier" or "IdentifierAttribute"))
                            .ToArray();
                    // Identifierが複数していされた場合、エラーとするがエラーはSourceAnalyzerで処理するため
                    // こちらではIdentifierが一つしか存在しなかった場合のみ処理する。
                    if (identifiers.Length == 1)
                    {
                        var identifySymbol = context.Compilation.GetSemanticModel(identifiers[0].SyntaxTree).GetDeclaredSymbol(identifiers[0]);

                        var equalsTemplate = new EqualsTemplate
                        {
                            Namespace = typeSymbol.ContainingNamespace.ToDisplayString(),
                            TypeName = typeSymbol.Name,
                            PropertyName = identifySymbol?.Name
                        };

                        context.AddSource($"{equalsTemplate.Namespace}.{equalsTemplate.TypeName}.Partial.cs", GenerateSource(equalsTemplate));
//                        context.AddSource($"{equalsTemplate.Namespace}.{equalsTemplate.TypeName}.Partial.cs", equalsTemplate.TransformText());
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.ToString());
            }
        }

        private string GenerateSource(EqualsTemplate equalsTemplate)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(@"namespace ");
            stringBuilder.Append(equalsTemplate.Namespace);
            stringBuilder.Append(@"
{
    public partial class ");
            stringBuilder.Append(equalsTemplate.TypeName);
            stringBuilder.Append(@"
    {
        public override bool Equals(object other)
        {
            if(other is ");
            stringBuilder.Append(equalsTemplate.TypeName);
            stringBuilder.Append(" ");
            stringBuilder.Append(equalsTemplate.TypeName.ToLower());
            stringBuilder.Append(@")
            {
                return ");
            stringBuilder.Append(equalsTemplate.PropertyName);
            stringBuilder.Append(".Equals(");
            stringBuilder.Append(equalsTemplate.TypeName.ToLower());
            stringBuilder.Append(".");
            stringBuilder.Append(equalsTemplate.PropertyName);
            stringBuilder.Append(@");
            }

            return false;
        }
    }
}
");
            return stringBuilder.ToString();
        }

        class SyntaxReceiver : ISyntaxReceiver
        {
            public List<TypeDeclarationSyntax> Targets { get; } = new();

            public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
            {
                if (syntaxNode is TypeDeclarationSyntax typeDeclarationSyntax)
                {
                    Targets.Add(typeDeclarationSyntax);
                }
            }
        }
    }
}
