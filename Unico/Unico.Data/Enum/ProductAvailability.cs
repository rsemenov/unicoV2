using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Attributes;

namespace Unico.Data.Enum
{
    public enum ProductAvailability
    {
        [Display(Name="Есть в наличии")]
        Available = 1,
        [Display(Name = "Нет в наличии")]
        NotAvailable = 2,
        [Display(Name = "Ожидаеться")]
        Soon = 3,
        [Display(Name = "Уточняйте")]
        Ask = 4       
    }

    public static class ProductAvailabilityExtensions
    {
        public static string ConvertToString(this ProductAvailability availability)
        {
            MemberInfo memberInfo = typeof(ProductAvailability).GetMember(availability.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                var attribute = (DisplayAttribute)memberInfo.GetCustomAttributes(typeof(DisplayAttribute), false)
                                       .FirstOrDefault();
                if (attribute != null)
                {
                    return attribute.Name;
                }
            }

            return String.Empty;
        }
    }
}
