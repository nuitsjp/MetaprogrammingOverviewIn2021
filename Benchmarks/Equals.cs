using BenchmarkDotNet.Attributes;
using Equals.Fody;
using Fody;
using NotMetaprogramming;

namespace Benchmarks
{
    public class Equals
    {
        private static readonly Customer NotGeneratedCustomer1 = new Customer { Code = 1 };
        private static readonly Customer NotGeneratedCustomer2 = new Customer { Code = 2 };

        private static readonly Reflection.Client.Customer ReflectionCustomer1 = new Reflection.Client.Customer {Code = 1};
        private static readonly Reflection.Client.Customer ReflectionCustomer2 = new Reflection.Client.Customer {Code = 2};

        private static readonly ReflectionWithCache.Customer ReflectionWithCacheCustomer1 = new ReflectionWithCache.Customer { Code = 1 };
        private static readonly ReflectionWithCache.Customer ReflectionWithCacheCustomer2 = new ReflectionWithCache.Customer { Code = 2 };

        private static readonly ExpressionTree.Customer ExpressionTreeCustomer1 = new ExpressionTree.Customer { Code = 1 };
        private static readonly ExpressionTree.Customer ExpressionTreeCustomer2 = new ExpressionTree.Customer { Code = 2 };

        private static readonly ExpressionTreeWithCache.Customer ExpressionTreeWithCacheCustomer1 = new ExpressionTreeWithCache.Customer { Code = 1 };
        private static readonly ExpressionTreeWithCache.Customer ExpressionTreeWithCacheCustomer2 = new ExpressionTreeWithCache.Customer { Code = 2 };

        private static readonly T4Template.Customer T4TemplateCustomer1 = new T4Template.Customer {Code = 1};
        private static readonly T4Template.Customer T4TemplateCustomer2 = new T4Template.Customer {Code = 2};

        private static readonly SourceGenerator.Customer SourceGeneratorCustomer1 = new SourceGenerator.Customer { Code = 1 };
        private static readonly SourceGenerator.Customer SourceGeneratorCustomer2 = new SourceGenerator.Customer { Code = 2 };

        private static readonly object IlGeneratorCustomer1;
        private static readonly object IlGeneratorCustomer2;

        static Equals()
        {
            var weavingTask = new ModuleWeaver();
            var testResult = weavingTask.ExecuteTestRun("ILGenerator.dll", false);

            var customer1 = testResult.GetInstance("ILGenerator.Customer");
            customer1.Code = 1;
            IlGeneratorCustomer1 = customer1;
            var customer2 = testResult.GetInstance("ILGenerator.Customer");
            customer2.Code = 1;
            IlGeneratorCustomer2 = customer2;
        }


        [Benchmark]
        public void NotGenerated() => NotGeneratedCustomer1.Equals(NotGeneratedCustomer2);

        [Benchmark]
        public void Reflection() => ReflectionCustomer1.Equals(ReflectionCustomer2);

        [Benchmark]
        public void ReflectionWithCache() => ReflectionWithCacheCustomer1.Equals(ReflectionWithCacheCustomer2);

        [Benchmark]
        public void ExpressionTree() => ExpressionTreeCustomer1.Equals(ExpressionTreeCustomer2);

        [Benchmark]
        public void ExpressionTreeWithCache() => ExpressionTreeWithCacheCustomer1.Equals(ExpressionTreeWithCacheCustomer2);

        [Benchmark]
        public void T4Template() => T4TemplateCustomer1.Equals(T4TemplateCustomer2);

        [Benchmark]
        public void SourceGenerator() => SourceGeneratorCustomer1.Equals(SourceGeneratorCustomer2);

        [Benchmark]
        public void StaticILGenerator() => IlGeneratorCustomer1.Equals(IlGeneratorCustomer2);
    }
}