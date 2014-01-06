using System.Collections.Generic;
namespace Unico.Data.Entities
{
    public class OcpProduct : Product
    {
        public virtual int OcpProductId { get; set; }
        public virtual string Key { get; set; }
        public virtual string Color { get; set; }
        public virtual string Weight { get; set; }
        public virtual IList<Cartrige> Cartriges { get; set; }
    }
}