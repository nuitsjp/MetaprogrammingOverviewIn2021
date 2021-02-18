// 該当のNuGetパッケージをImportしてもいいが、特に必要がないのであれば、パッケージの依存を
// 増やさないため、中身のない実装を用意することで、参照パッケージを減らすことができる。
// ReSharper disable once CheckNamespace
namespace System.CodeDom.Compiler
{
    public class CompilerError
    {
        public string ErrorText { get; set; }
        public bool IsWarning { get; set; }
    }

    public class CompilerErrorCollection
    {
        public void Add(CompilerError error)
        {
        }
    }
}