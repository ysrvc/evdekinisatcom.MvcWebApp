using evdekinisatcom.MvcWebApp.Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp.Entity.Services
{
    public interface ICommentService
    {
        Task<List<CommentViewModel>> GetAllByProductId(int Id);
        Task Add(CommentViewModel model);
    }
}
