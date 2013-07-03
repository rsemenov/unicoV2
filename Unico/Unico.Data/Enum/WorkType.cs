using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Attributes;

namespace Unico.Data.Enum
{
    public enum WorkType
    {
        [Display(Name="Продажа")]
        Sell = 1,
        [Display(Name = "Обслуживание")]
        Service = 2
    }    
}
