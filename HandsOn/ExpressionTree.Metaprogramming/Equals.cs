using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Commons;

namespace ExpressionTree.Metaprogramming
{
    public static class Equals<T>
    {
        public static bool Invoke(T self, object other)
        {
            if (other is T t)
            {
                var identifyProperty = typeof(T)
                    .GetProperties()
                    .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null);

                return Equals(identifyProperty.GetValue(self), identifyProperty.GetValue(t));
            }

            return false;
        }
    }
}
