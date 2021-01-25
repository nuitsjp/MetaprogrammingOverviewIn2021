using System;
using System.Reflection;

namespace ExpressionTreeWithCache
{
    public class Cache<T>
    {
        public static Func<T, int> GetIdentify;
    }
}