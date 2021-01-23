using Commons;

namespace ReflectionWithCache
{
    public class Employee : EntityBase<Employee>
    {
        [Identifier]
        public int Id { get; set; }
    }
}
