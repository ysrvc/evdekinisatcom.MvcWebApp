using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class OrderDetail :BaseEntity
    {
        
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Number { get; set; }

        public decimal UnitPrice { get; set; }

        //Navigation Property
        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
