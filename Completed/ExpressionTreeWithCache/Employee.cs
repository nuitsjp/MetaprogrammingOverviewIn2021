using Commons;
using ExpressionTreeWithCache.Metaprogramming;

namespace ExpressionTreeWithCache
{
    public class Employee
    {
        [Identifier]
        public int Id { get; set; }

        public override bool Equals(object obj)
            => Equals<Employee>.Invoke(this, obj);
    }
}
