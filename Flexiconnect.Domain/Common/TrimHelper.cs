using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flexiconnect.Domain.Common
{
    public static class TrimHelper
    {
        public static void TrimAllStrings<T>(T obj)
        {
            if (obj == null) return;

            var stringProps = typeof(T).GetProperties()
                .Where(p => p.PropertyType == typeof(string) && p.CanRead && p.CanWrite);

            foreach (var prop in stringProps)
            {
                var currentValue = prop.GetValue(obj) as string;
                if (currentValue != null)
                {
                    prop.SetValue(obj, currentValue.Trim());
                }
            }
        }
        public static void TrimAllStringsInList<T>(List<T> list)
        {
            if (list == null) return;
            foreach (var item in list)
            {
                TrimAllStrings(item);
            }
        }
    }
}
