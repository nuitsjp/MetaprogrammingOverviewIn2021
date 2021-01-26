using Commons;
using Reflection.Service;

namespace Reflection
{
    public class Employee
    {
        [Identifier]
        public int Id { get; set; }

        public override bool Equals(object obj)
            => this.InvokeEquals(obj);
    }
}
