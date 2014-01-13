using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Attributes;

namespace Unico.Data.Enum
{
    public enum AccountRole
    {        
        User = 1,
        Client = 2,
        Administrator = 3
    }

    public enum EmailTypeEnum
    {
        OrderConfirmation = 1,
        NewOrderCreated = 2,
    }
}
