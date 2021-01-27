using Commons;
using ExpressionTree.Service;

namespace ExpressionTree.Client
{
    public class Employee
    {
        [Identifier]
        public int Id { get; set; }

        public override bool Equals(object obj)
            => this.InvokeEquals(obj);
    }
}
