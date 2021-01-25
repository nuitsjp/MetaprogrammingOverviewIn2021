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

            var castToObject = Expression.Convert(getterCall, typeof(int));
            var lambda = Expression.Lambda(castToObject, entity);

            var getIdentify = (Func<T, int>)lambda.Compile();

            return getIdentify((T) (object) this).Equals(getIdentify((T) obj));
        }
    }
}