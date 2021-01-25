using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Commons;

namespace ExpressionTreeWithCache
{
    public abstract class EntityBase<T>
    {
        static EntityBase()
        {
            var getIdentifyMethod = typeof(T)
                .GetProperties()
                .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null)
                .GetGetMethod();

            var entity = Expression.Parameter(typeof(T));
            var getterCall = Expression.Call(entity, getIdentifyMethod);

            var castToObject = Expression.Convert(getterCall, typeof(int));
            var lambda = Expression.Lambda(castToObject, entity);

            var getIdentify = (Func<T, int>)lambda.Compile();

            Cache<T>.GetIdentify = getIdentify;
        }
        public override bool Equals(object obj)
        {
            var getIdentify = Cache<T>.GetIdentify;

            return getIdentify((T)(object)this).Equals(getIdentify((T)obj));
        }
    }
}