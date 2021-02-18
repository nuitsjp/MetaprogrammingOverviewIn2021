namespace T4Template
{
    public partial class Customer
    {
        public override bool Equals(object other)
        {
            if (other is Customer customer)
            {
                return Code.Equals(customer.Code);
            }

            return false;
        }
    }
}