using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Commons;

namespace ExpressionTree
{
    public abstract class EntityBase<T>
    {
        public override bool Equals(object obj)
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

            return Equals(getIdentify((T)(object)this), getIdentify((T)obj));
        }
    }
}