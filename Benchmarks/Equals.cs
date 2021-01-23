using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class Equals
    {
        private readonly NotGenerated.Customer _notGeneratedCustomer1 = new NotGenerated.Customer { Code = 1 };
        private readonly NotGenerated.Customer _notGeneratedCustomer2 = new NotGenerated.Customer { Code = 2 };

        private readonly Reflection.Customer _reflectionCustomer1 = new Reflection.Customer {Code = 1};
        private readonly Reflection.Customer _reflectionCustomer2 = new Reflection.Customer {Code = 2};

        private readonly ReflectionWithCache.Customer _reflectionWithCacheCustomer1 = new ReflectionWithCache.Customer { Code = 1 };
        private readonly ReflectionWithCache.Customer _reflectionWithCacheCustomer2 = new ReflectionWithCache.Customer { Code = 2 };

        private readonly ExpressionTree.Customer _expressionTreeCustomer1 = new ExpressionTree.Customer { Code = 1 };
        private readonly ExpressionTree.Customer _expressionTreeCustomer2 = new ExpressionTree.Customer { Code = 2 };

        private readonly ExpressionTreeWithCache.Customer _expressionTreeWithCacheCustomer1 = new ExpressionTreeWithCache.Customer { Code = 1 };
        private readonly ExpressionTreeWithCache.Customer _expressionTreeWithCacheCustomer2 = new ExpressionTreeWithCache.Customer { Code = 2 };

        private readonly T4Template.Customer _t4TemplateCustomer1 = new T4Template.Customer {Code = 1};
        private readonly T4Template.Customer _t4TemplateCustomer2 = new T4Template.Customer {Code = 2};

        private readonly SourceGenerator.Customer _sourceGeneratorCustomer1 = new SourceGenerator.Customer { Code = 1 };
        private readonly SourceGenerator.Customer _sourceGeneratorCustomer2 = new SourceGenerator.Customer { Code = 2 };

        [Benchmark]
        public void NotGenerated() => _notGeneratedCustomer1.Equals(_notGeneratedCustomer2);

        [Benchmark]
        public void Reflection() => _reflectionCustomer1.Equals(_reflectionCustomer2);

        [Benchmark]
        public void ReflectionWithCache() => _reflectionWithCacheCustomer1.Equals(_reflectionWithCacheCustomer2);

        [Benchmark]
        public void ExpressionTree() => _expressionTreeCustomer1.Equals(_expressionTreeCustomer2);

        [Benchmark]
        public void ExpressionTreeWithCache() => _expressionTreeWithCacheCustomer1.Equals(_expressionTreeWithCacheCustomer2);

        [Benchmark]
        public void T4Template() => _t4TemplateCustomer1.Equals(_t4TemplateCustomer2);

        [Benchmark]
        public void SourceGenerator() => _sourceGeneratorCustomer1.Equals(_sourceGeneratorCustomer2);
    }
}