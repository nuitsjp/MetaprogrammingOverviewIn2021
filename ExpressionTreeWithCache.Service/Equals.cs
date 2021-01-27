using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Commons;

namespace ExpressionTreeWithCache.Service
{
    public class Equals<T>
    {
        public static Equals<T> Instance = new();

        private readonly Func<T, int> _getIdentify;

        private Equals()
        {
            var getIdentifyMethod = typeof(T)
                .GetProperties()
                .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null)
                .GetGetMethod();

            var entity = Expression.Parameter(typeof(T));
            var getterCall = Expression.Call(entity, getIdentifyMethod);
            var lambda = Expression.Lambda(getterCall, entity);

            var getIdentify = (Func<T, int>)lambda.Compile();

            _getIdentify = getIdentify;
        }

        public static bool Invoke(T self, object other) => Instance.InvokeInner(self, other);

        private bool InvokeInner(T self, object other)
        {
            if (other is T t)
            {
                return _getIdentify(self).Equals(_getIdentify(t));
            }

            return false;
        }
    }
}
