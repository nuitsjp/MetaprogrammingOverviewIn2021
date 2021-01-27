using System.Linq;
using System.Reflection;
using Commons;

namespace ReflectionWithCache.Service
{
    public class Equals<T>
    {
        public static Equals<T> Instance = new();

        private readonly PropertyInfo _propertyInfo;


        private Equals()
        {
            _propertyInfo = typeof(T)
                .GetProperties()
                .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null);
        }

        public static bool Invoke(T self, object other) => Instance.InvokeInner(self, other);

        private bool InvokeInner(T self, object other)
        {
            if (other is T t)
            {
                return Equals(_propertyInfo.GetValue(self), _propertyInfo.GetValue(t));
            }

            return false;
        }
    }
}