using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Web.Utils
{
    public static class EnumUtils
    {
        public static string GetDescription(this Enum sex)
        {
            FieldInfo info = sex.GetType().GetField(sex.ToString());
            DescriptionAttribute[] attributes = info.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return sex.ToString();
        }   
    }
}
