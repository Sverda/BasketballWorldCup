using System;
using System.ComponentModel;
using System.Linq;

namespace BasketballWorldCup.Model.Helpers
{
    public static class EnumHelper
    {
        public static string GetDescription(this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var customAttributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (!(customAttributes is DescriptionAttribute[] attributes) || !attributes.Any())
            {
                return value.ToString();
            }

            return attributes.First().Description;
        }
    }
}
