using Commons;

namespace ExpressionTreeWithCache
{
    public class Employee : EntityBase<Employee>
    {
        [Identifier]
        public int Id { get; set; }
    }
}
