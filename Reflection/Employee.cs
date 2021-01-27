using Commons;
using Reflection.Service;

namespace Reflection.Client
{
    public class Employee
    {
        [Identifier]
        public int Id { get; set; }

        public override bool Equals(object obj)
            => this.InvokeEquals(obj);
    }
}
