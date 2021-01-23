using Xunit;

namespace ExpressionTree.Test
{
    namespace GenerateEqualsTest
    {
        public class EqualsがIdentifier属性で指定されたプロパティで行われること
        {
            [Fact]
            public void Identifier属性の指定されたプロパティ名がCodeである()
            {
                var customer1 = new Customer { Code = 1 };
                var customer2 = new Customer { Code = 1 };
                Assert.True(customer1.Equals(customer2));
            }

            [Fact]
            public void Identifier属性の指定されたプロパティ名がIdである()
            {
                var employee1 = new Employee { Id = 1 };
                var employee2 = new Employee { Id = 1 };
                Assert.True(employee1.Equals(employee2));
            }
        }
    }
}
