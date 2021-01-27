using System.Linq;
using System.Reflection;
using Commons;

namespace ReflectionWithCache.Service
{
    public class Equals<T>
    {
        private static PropertyInfo PropertyInfo;

        static Equals()
        {
            PropertyInfo = typeof(T)
                .GetProperties()
                .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null);

        }

        public static bool Invoke(T self, object other)
        {
            if (other is T t)
            {
                return Equals(PropertyInfo.GetValue(self), PropertyInfo.GetValue(t));
            }

            return false;
        }
    }
}