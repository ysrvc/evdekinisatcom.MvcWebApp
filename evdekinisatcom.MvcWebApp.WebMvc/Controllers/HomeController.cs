using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using evdekinisatcom.MvcWebApp_App.WebMvc.Models;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;

namespace evdekinisatcom.MvcWebApp_App.WebMvc.Controllers
{
    public class HomeController : Controller
    {

        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _uow;


        public HomeController(IMapper mapper, IProductService productService, ICategoryService categoryService, IUnitOfWork uow)
        {
            _mapper = mapper;
            _productService = productService;
            _categoryService = categoryService;
            _uow = uow;
        }

       

        public async Task<IActionResult> Index(ProductViewModel model, string? search)
        {

            var list = await _uow.GetRepository<Product>().GetAll(c => c.isBoosted == "Evet");

            if (search != null)
            {
                list = await _uow.GetRepository<Product>().GetAll();
                list = list.Where(a => a.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            return View(_mapper.Map<List<ProductViewModel>>(list));


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}