using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class Category : BaseEntity
    {

        public string Name { get; set; }

        public int ParentCategoryId { get; set; }

        //Navigation Property
        public virtual List<Product> Products { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual List<Category> subCategories { get; set; }


    }
}
