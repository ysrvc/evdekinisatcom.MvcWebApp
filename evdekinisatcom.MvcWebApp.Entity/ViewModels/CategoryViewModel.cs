using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

namespace evdekinisatcom.MvcWebApp_App.Service.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        






    }
}
