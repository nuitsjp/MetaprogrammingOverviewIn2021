using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Commons;

namespace ExpressionTree.Service
{
    public static class Equals<T>
    {
        public static bool Invoke(T self, object other)
        {
            if (other is T t)
            {
                var getIdentifyMethod = typeof(T)
                    .GetProperties()
                    .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null)
                    .GetGetMethod();

                var entity = Expression.Parameter(typeof(T));
                var getterCall = Expression.Call(entity, getIdentifyMethod);
                var lambda = Expression.Lambda(getterCall, entity);

                var getIdentify = (Func<T, int>)lambda.Compile();

                return getIdentify(self).Equals(getIdentify(t));
            }

            return false;
        }
    }
}
