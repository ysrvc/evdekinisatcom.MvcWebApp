using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace evdekinisatcom.MvcWebApp.WebMvc.ViewComponents
{
    public class AramaViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly IUnitOfWork _uow;
        public AramaViewComponent (IMapper mapper, IProductService productService, IUnitOfWork uow)
        {
            _mapper = mapper;
            _productService = productService;
            _uow = uow;
        }

        public async Task<IViewComponentResult> InvokeAsync(ProductViewModel model, string search)
        {
            
                var list = await _uow.GetRepository<Product>().GetAll();
                list = list.Where(a => a.Title.ToLower().Contains(search.ToLower())).ToList();
                 return View(_mapper.Map<List<ProductViewModel>>(list));

        }
    }
}
