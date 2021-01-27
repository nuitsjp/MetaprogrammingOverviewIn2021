using Commons;
using ExpressionTreeWithCache.Service;

namespace ExpressionTreeWithCache.Client
{
    public class Customer
    {
        [Identifier]
        public int Code { get; set; }

        public override bool Equals(object obj)
            => Equals<Customer>.Invoke(this, obj);
    }
}