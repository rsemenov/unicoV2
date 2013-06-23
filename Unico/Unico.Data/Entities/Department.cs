using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unico.Data.Interfaces;

namespace Unico.Data.Entities
{
    public class Department:IEntity
    {
        public virtual int DepartmentId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Category> Categories { get; set; }
    }
}
