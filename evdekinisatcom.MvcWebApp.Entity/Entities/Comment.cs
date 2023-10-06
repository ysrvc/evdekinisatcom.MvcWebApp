using evdekinisatcom.MvcWebApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evdekinisatcom.MvcWebApp_App.Entity.Entities
{
    public class Comment : BaseEntity
    {
        
        public string Content { get; set; }        

        public int UserId { get; set; }

        public string Username { get; set; }

        public  string UserProfilePic { get; set; }

        public int ProductId { get; set; }
        //Navigation Property
        public virtual Product Product { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
