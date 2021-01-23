using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class Equals
    {
        private readonly T4Template.Customer _t4TemplateCustomer1 = new T4Template.Customer {Code = 1};
        private readonly T4Template.Customer _t4TemplateCustomer2 = new T4Template.Customer {Code = 2};

        private readonly NotGenerated.Customer _notGeneratedCustomer1 = new NotGenerated.Customer {Code = 1};
        private readonly NotGenerated.Customer _notGeneratedCustomer2 = new NotGenerated.Customer {Code = 2};

        [Benchmark]
        public void NotGenerated() => _notGeneratedCustomer1.Equals(_notGeneratedCustomer2);

        [Benchmark]
        public void T4Template() => _t4TemplateCustomer1.Equals(_t4TemplateCustomer2);
    }
}