using System;
using System.Linq;
using System.Reflection;
using Commons;

namespace Reflection
{
    public abstract class EntityBase<T>
    {
        public override bool Equals(object obj)
        {
            var identifyProperty = typeof(T)
                .GetProperties()
                .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null);

            return Equals(identifyProperty.GetValue(this), identifyProperty.GetValue(obj));
        }
    }
}