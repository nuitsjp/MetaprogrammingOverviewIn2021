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

            var castToObject = Expression.Convert(getterCall, typeof(object));
            var lambda = Expression.Lambda(castToObject, entity);

            var getIdentify = (Func<T, object>)lambda.Compile();

            Cache<T>.GetIdentify = getIdentify;
        }
        public override bool Equals(object obj)
        {
            var getIdentify = Cache<T>.GetIdentify;

            return Equals(getIdentify((T)(object)this), getIdentify((T)obj));
        }
    }
}