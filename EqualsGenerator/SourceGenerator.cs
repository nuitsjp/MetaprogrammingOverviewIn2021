using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EqualsGenerator
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

                    var identifyProperty =
                        targetType.Members
                            .Single(x => x
                                .AttributeLists
                                .SelectMany(attribute => attribute.Attributes)
                                .Any(attribute => attribute.Name.ToString() is "Identifier" or "IdentifierAttribute"));
                    var identifySymbol = context.Compilation.GetSemanticModel(identifyProperty.SyntaxTree).GetDeclaredSymbol(identifyProperty);

                    var equalsTemplate = new EqualsTemplate
                    {
                        Namespace = typeSymbol.ContainingNamespace.ToDisplayString(),
                        TypeName = typeSymbol.Name,
                        PropertyName = identifySymbol?.Name
                    };

                    context.AddSource($"{equalsTemplate.Namespace}.{equalsTemplate.TypeName}.Partial.cs", equalsTemplate.TransformText());
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.ToString());
            }
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
