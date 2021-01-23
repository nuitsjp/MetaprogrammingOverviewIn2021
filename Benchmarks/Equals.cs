using BenchmarkDotNet.Attributes;
using Entities;

namespace Benchmarks
{
    public class Equals
    {
        private readonly Customer _t4TemplateCustomer1 = new Customer {Code = 1};
        private readonly Customer _t4TemplateCustomer2 = new Customer {Code = 2};

        [Benchmark]
        public void T4Template() => _t4TemplateCustomer1.Equals(_t4TemplateCustomer2);
    }
}