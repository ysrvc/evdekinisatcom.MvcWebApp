using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

namespace evdekinisatcom.MvcWebApp_App.Service.ViewModels
{
    public class ProductIndexViewModel
    {
        public string SearchTerm { get; set; } // Arama terimi için
        public int? SelectedCategoryId { get; set; } // Seçilen kategori ID'si için
        public List<Category> Categories { get; set; } // Tüm kategorileri listelemek için
        public List<ProductViewModel> Products { get; set; } // Ürünleri listelemek için
        public int CurrentPage { get; set; } // Mevcut sayfa numarası için
        public int TotalPages { get; set; } // Toplam sayfa sayısı için
    }
}
