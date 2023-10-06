using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

namespace evdekinisatcom.MvcWebApp.DataAccess.Identity.Models
{
    public class AppUser : IdentityUser<int>
    {       
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }

        public string ProfilePicUrl { get; set; }

        public decimal Balance { get; set; }

        //Navigation Property (Relation)

        public List<Order> Orders { get; set; }
        public List<Product> ProductsToSell { get; set; }
        public List<Product> PurchasedProducts { get; set; }


    }
}
