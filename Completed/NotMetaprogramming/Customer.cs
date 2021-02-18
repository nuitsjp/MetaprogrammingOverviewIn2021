namespace NotMetaprogramming
{
    public class Customer
    {
        public int Code { get; set; }
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
