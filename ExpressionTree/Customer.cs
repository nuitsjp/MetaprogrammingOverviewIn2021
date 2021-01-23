using Commons;

namespace ExpressionTree
{
    public class Customer : EntityBase<Customer>
    {
        [Identifier]
        public int Code { get; set; }
    }
}