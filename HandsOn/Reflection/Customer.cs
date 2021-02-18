using System;
using Commons;
using Reflection.Metaprogramming;

namespace Reflection
{
    public class Customer
    {
        [Identifier]
        public int Code { get; set; }

        public override bool Equals(object other)
        {
            if (other is Customer customer)
            {
                return Code.Equals(customer.Code);
            }

            return false;
        }
    }
}