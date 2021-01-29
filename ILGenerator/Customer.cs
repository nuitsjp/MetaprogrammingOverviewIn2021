using Commons;

namespace Fody
{
    public partial class Customer
    {
        [Identifier]
        public int Code { get; set; }
    }
}