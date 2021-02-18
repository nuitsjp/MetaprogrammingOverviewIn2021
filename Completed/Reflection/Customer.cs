using Commons;
using Reflection.Metaprogramming;

namespace Reflection
{
    public class Customer
    {
        [Identifier]
        public int Code { get; set; }

        public override bool Equals(object obj)
            => Equals<Customer>.Invoke(this, obj);
    }
}