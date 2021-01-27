using System.Linq;
using System.Reflection;
using Commons;

namespace ReflectionWithCache.Service
{
    public static class ObjectExtensions
    {
        public static bool InvokeEquals<T>(this T self, object other)
        {
            if (other is T t)
            {
                var identifyProperty = Cache<T>.PropertyInfo;

                return Equals(identifyProperty.GetValue(self), identifyProperty.GetValue(t));
            }

            return false;
        }

        private static class Cache<T>
        {
            public static PropertyInfo PropertyInfo;

            static Cache()
            {
                PropertyInfo = typeof(T)
                    .GetProperties()
                    .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null);

            }
        }

    }
}