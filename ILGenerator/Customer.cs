using Commons;

namespace Fody.Client
{
    public partial class Customer
    {
        [Identifier]
        public int Code { get; set; }
    }
}