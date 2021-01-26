using System;
using System.Linq;
using System.Reflection;
using Commons;

namespace Reflection.Service
{
    public static class ObjectExtensions
    {
        public static bool InvokeEquals<T>(this T self, object other)
        {
            if (other is T t)
            {
                var identifyProperty = typeof(T)
                    .GetProperties()
                    .Single(x => x.GetCustomAttribute<IdentifierAttribute>() is not null);

                return Equals(identifyProperty.GetValue(self), identifyProperty.GetValue(t));
            }

            return false;
        }
    }
}
