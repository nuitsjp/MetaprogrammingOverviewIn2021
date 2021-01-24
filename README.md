# C#メタプログラミング概略 in 2021

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.746 (2004/?/20H1)
Intel Core i7-7700T CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  DefaultJob : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT


```
|                  Method |           Mean |         Error |        StdDev |
|------------------------ |---------------:|--------------:|--------------:|
|            NotGenerated |       2.276 ns |     0.0199 ns |     0.0186 ns |
|              Reflection |   2,935.931 ns |    23.8237 ns |    22.2847 ns |
|     ReflectionWithCache |     222.600 ns |     2.5681 ns |     2.1445 ns |
|          ExpressionTree | 103,915.357 ns | 1,536.3218 ns | 1,437.0764 ns |
| ExpressionTreeWithCache |      28.355 ns |     0.2319 ns |     0.2170 ns |
|              T4Template |       2.603 ns |     0.0200 ns |     0.0167 ns |
|         SourceGenerator |       2.261 ns |     0.0253 ns |     0.0237 ns |
|       StaticILGenerator |       2.770 ns |     0.0208 ns |     0.0185 ns |
