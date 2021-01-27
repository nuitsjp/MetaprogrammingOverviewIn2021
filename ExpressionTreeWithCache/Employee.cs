using Commons;
using ExpressionTreeWithCache.Service;

namespace ExpressionTreeWithCache.Client
{
    public class Employee
    {
        [Identifier]
        public int Id { get; set; }

        public override bool Equals(object obj)
            => this.InvokeEquals(obj);
    }
}
