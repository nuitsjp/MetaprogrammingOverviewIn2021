namespace T4Template
{
    public partial class Employee
    {
        public override bool Equals(object other)
        {
            if(other is Employee employee)
            {
                return Id.Equals(employee.Id);
            }

            return false;
        }
    }
    public partial class Customer
    {
        public override bool Equals(object other)
        {
            if(other is Customer customer)
            {
                return Code.Equals(customer.Code);
            }

            return false;
        }
    }
}
