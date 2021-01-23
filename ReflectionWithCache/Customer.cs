using Commons;

namespace ReflectionWithCache
{
    public class Customer : EntityBase<Customer>
    {
        [Identifier]
        public int Code { get; set; }
    }
}