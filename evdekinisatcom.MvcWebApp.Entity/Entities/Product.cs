using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class Product : BaseEntity
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Condition { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public string HeaderImageUrl { get; set; }

        public int CategoryId { get; set; }

        public int SellerId { get; set; } //Seller
        public string SellerUsername { get; set; }
        public bool IsOnSale { get; set; } = true;

        public int? BuyerId { get; set; } //Buyer

        //Navigation Property

        public virtual Category Category { get; set; }

        public virtual List<ProductImage> Images { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<Comment> Comments { get; set; }




    }
}
