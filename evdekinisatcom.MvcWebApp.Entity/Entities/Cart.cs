using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class Cart : BaseEntity
    {        

        public int UserId { get; set; }        

        //Navigation Property
        public virtual List<Product> Products { get; set; }
    }
}
