using Commons;

namespace Reflection
{
    public class Customer : EntityBase<Customer>
    {
        [Identifier]
        public int Code { get; set; }
    }
}