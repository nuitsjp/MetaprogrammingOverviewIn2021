using Commons;
using Reflection.Metaprogramming;

namespace Reflection
{
    public class Employee
    {
        [Identifier]
        public int Id { get; set; }

        public override bool Equals(object other)
        {
            if (other is Employee employee)
            {
                return Id.Equals(employee.Id);
            }

            return false;
        }
    }
}
