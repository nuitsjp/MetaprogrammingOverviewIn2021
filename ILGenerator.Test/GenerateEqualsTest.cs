using Equals.Fody;
using Fody;
using Xunit;

namespace ILGenerator.Test
{
    namespace GenerateEqualsTest
    {
        public class EqualsがIdentifier属性で指定されたプロパティで行われること
        {
            private static readonly TestResult TestResult;

            static EqualsがIdentifier属性で指定されたプロパティで行われること()
            {
                var weavingTask = new ModuleWeaver();
                TestResult = weavingTask.ExecuteTestRun("ILGenerator.dll", false);
            }

            [Fact]
            public void Identifier属性の指定されたプロパティ名がCodeである()
            {
                var customer1 = TestResult.GetInstance("ILGenerator.Customer");
                customer1.Code = 1;
                var customer2 = TestResult.GetInstance("ILGenerator.Customer");
                customer2.Code = 1;
                Assert.True(customer1.Equals(customer2));
            }

            [Fact]
            public void Identifier属性の指定されたプロパティ名がIdである()
            {
                var employee1 = TestResult.GetInstance("ILGenerator.Employee");
                employee1.Id = 1;
                var employee2 = TestResult.GetInstance("ILGenerator.Employee");
                employee2.Id = 1;
                Assert.True(employee1.Equals(employee2));
            }
        }
    }
}
