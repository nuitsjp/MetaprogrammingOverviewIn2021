using System.Linq;
using System.Reflection;
using Commons;

namespace ReflectionWithCache
{
    public abstract class EntityBase<T>
    {
        static EntityBase()
        {
            Cache<T>.PropertyInfo = typeof(T)
                .GetProperties()
                .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null);
        }
        public override bool Equals(object obj)
        {
            var identifyProperty = Cache<T>.PropertyInfo;

            return Equals(identifyProperty.GetValue(this), identifyProperty.GetValue(obj));
        }
    }
}