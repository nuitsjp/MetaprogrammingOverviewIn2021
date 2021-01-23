using Commons;

namespace ExpressionTreeWithCache
{
    public class Customer : EntityBase<Customer>
    {
        [Identifier]
        public int Code { get; set; }
    }
}