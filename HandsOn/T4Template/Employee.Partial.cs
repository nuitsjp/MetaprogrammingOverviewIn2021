using Commons;

namespace T4Template
{
    public partial class Employee
    {
        public override bool Equals(object other)
        {
            if (other is Employee employee)
            {
                return Id.Equals(employee.Id);
            }

            return false;
        }
    }
}
