using System.Linq;

namespace Domain
{
    public static class Extensions
    {
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }
    }
}