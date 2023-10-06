using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp.Entity.Repositories;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;

namespace evdekinisatcom.MvcWebApp_App.Service.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IMapper _mapper;
        IRepository<Category> _categoryRepo;

        public CategoryViewComponent(IRepository<Category> categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //ViewBag.SelectedCategoryId = RouteData?.Values["id"];
            var categories = await _categoryRepo.GetAllAsync();
            return View(_mapper.Map<List<CategoryViewModel>>(categories));
        }
    }
}
