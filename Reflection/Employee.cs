using Commons;

namespace Reflection
{
    public class Employee : EntityBase<Employee>
    {
        [Identifier]
        public int Id { get; set; }
    }
}
