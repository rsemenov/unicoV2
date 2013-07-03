using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Attributes;

namespace Unico.Data.Enum
{
    public enum OrderStatus
    {
        [Display(Name="Новая")]
        New = 1,
        [Display(Name = "В работе")]
        Processing = 2,
		[Display(Name = "Выплонено")]
        Finished = 3,
		[Display(Name = "Выполнено и доставлено")]
        FinishedDelivered = 4		
    }    
}
