# C#メタプログラミング概略 in 2021

``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.746 (2004/?/20H1)
Intel Core i7-7700T CPU 2.90GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.102
  [Host]     : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT
  DefaultJob : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT


```
|                  Method |          Mean |       Error |      StdDev |
|------------------------ |--------------:|------------:|------------:|
|            NotGenerated |      2.798 ns |   0.0174 ns |   0.0154 ns |
|              Reflection |  2,891.742 ns |  15.2036 ns |  12.6957 ns |
|     ReflectionWithCache |    214.812 ns |   0.3982 ns |   0.3109 ns |
|          ExpressionTree | 85,835.928 ns | 897.0680 ns | 839.1179 ns |
| ExpressionTreeWithCache |      7.914 ns |   0.0504 ns |   0.0393 ns |
|              T4Template |      2.251 ns |   0.0125 ns |   0.0104 ns |
|         SourceGenerator |      2.259 ns |   0.0185 ns |   0.0173 ns |
|       StaticILGenerator |      2.584 ns |   0.0101 ns |   0.0079 ns |
