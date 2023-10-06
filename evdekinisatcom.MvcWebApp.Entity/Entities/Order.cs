using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class Order : BaseEntity
    {
        
        public int UserId { get; set; } //Buyer Id        

        public int TotalQuantity { get; set; }        

        public decimal TotalPrice { get; set; }

        //Navigation Property
        public virtual List<OrderDetail> OrderDetails { get; set; }




    }
}
