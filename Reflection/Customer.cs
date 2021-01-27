using Commons;
using Reflection.Service;

namespace Reflection.Client
{
    public class Customer
    {
        [Identifier]
        public int Code { get; set; }

        public override bool Equals(object obj)
            => Equals<Customer>.Invoke(this, obj);
    }
}