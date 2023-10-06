using AutoMapper;
using Azure;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using evdekinisatcom.MvcWebApp_App.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Service.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;

		public CategoryService(IUnitOfWork uow, IMapper mapper)
		{
			_uow = uow;
			_mapper = mapper;
		}
		public async Task<List<CategoryViewModel>> GetAll()
		{
			var list = await _uow.GetRepository<Category>().GetAll();
			return _mapper.Map<List<CategoryViewModel>>(list);
		}
	}
}
