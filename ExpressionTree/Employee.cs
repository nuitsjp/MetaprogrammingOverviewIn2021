using Commons;

namespace ExpressionTree
{
    public class Employee : EntityBase<Employee>
    {
        [Identifier]
        public int Id { get; set; }
    }
}
