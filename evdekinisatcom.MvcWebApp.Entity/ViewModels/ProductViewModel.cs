using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

namespace evdekinisatcom.MvcWebApp_App.Service.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int SellerId { get; set; }

        public string SellerUsername { get; set; }

        [Required(ErrorMessage = "Ürün Başlığı Yazmalısınız! ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Ürünün Hakkında Açıklama Yazmalısınız! ")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bir Fiyat Yazmalısınız! ")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Lütfen Ürünün Durumunu Belirtin! ")]
        public string Condition { get; set; }

		[Required(ErrorMessage = "Lütfen Ürünün Markasını Belirtin! ")]

		public string Brand { get; set; }
        [Required(ErrorMessage = "Lütfen Ürünün Rengini Belirtin! ")]

        public string Color { get; set; }

        public string HeaderImageUrl { get; set; }

        public List<ProductImage> Images { get; set; }
        

        public string? ReturnUrl { get; set; }

        public List<Comment> Comments { get; set; }

        




    }
}
