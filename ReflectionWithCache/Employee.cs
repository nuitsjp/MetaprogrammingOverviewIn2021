using Commons;
using ReflectionWithCache.Service;

namespace ReflectionWithCache
{
    public class Employee
    {
        [Identifier]
        public int Id { get; set; }

        public override bool Equals(object obj)
            => this.InvokeEquals(obj);
    }
}