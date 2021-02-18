using System.Linq;
using System.Reflection;
using Commons;

namespace Reflection.Metaprogramming
{
    public static class Equals<T>
    {
        public static bool Invoke(T self, object other)
        {
            return false;
        }
    }
}
