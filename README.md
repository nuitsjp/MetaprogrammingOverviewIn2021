# C#メタプログラミング概略 in 2021

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.746 (2004/?/20H1)
Intel Core i7-7700T CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  DefaultJob : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT


```
|                  Method |       Mean |     Error |    StdDev |
|------------------------ |-----------:|----------:|----------:|
|            NotGenerated |   2.357 ns | 0.0711 ns | 0.0630 ns |
|     ReflectionWithCache | 224.730 ns | 2.1112 ns | 1.6483 ns |
| ExpressionTreeWithCache |  18.491 ns | 0.3962 ns | 0.4239 ns |
|              T4Template |   2.838 ns | 0.0808 ns | 0.0716 ns |
|         SourceGenerator |   2.729 ns | 0.0785 ns | 0.0696 ns |
|       StaticILGenerator |   2.832 ns | 0.0220 ns | 0.0205 ns |
