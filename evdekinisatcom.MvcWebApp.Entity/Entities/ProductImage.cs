using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class ProductImage : BaseEntity
    {
        
        public string ImageUrl { get; set; }

        public int ProductId { get; set; }

        //Navigation property
        public virtual Product Product { get; set; }
    }
}
