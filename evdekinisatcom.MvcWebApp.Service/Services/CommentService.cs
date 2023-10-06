using AutoMapper;
using evdekinisatcom.MvcWebApp.Entity.Services;
using evdekinisatcom.MvcWebApp.Entity.UnitOfWorks;
using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using evdekinisatcom.MvcWebApp_App.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CommentService(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task Add(CommentViewModel model)
        {
            Comment comment = new Comment();
            comment = _mapper.Map<Comment>(model);
            await _uow.GetRepository<Comment>().Add(comment);
            await _uow.CommitAsync();
        }

        public async Task<List<CommentViewModel>> GetAllByProductId(int Id)
        {
            var list = await _uow.GetRepository<Comment>().GetAll(c => c.ProductId == Id);
            return _mapper.Map<List<CommentViewModel>>(list);
        }
    }
}

