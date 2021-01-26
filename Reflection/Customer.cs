using System.Runtime.CompilerServices;
using Commons;
using Reflection.Service;

namespace Reflection
{
    public class Customer
    {
        [Identifier]
        public int Code { get; set; }

        public override bool Equals(object obj)
            => this.InvokeEquals(obj);
    }
}