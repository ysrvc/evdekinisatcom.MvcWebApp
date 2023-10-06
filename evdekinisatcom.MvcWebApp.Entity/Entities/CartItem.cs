using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class CartItem : BaseEntity
    {
        
        public int Quantity { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public int ProductId { get; set; }

        //Navigation Property
        public virtual Product Product { get; set; }
    }
}
