using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Blog> Blogs { get; set;}
        public virtual Role Role { get; set;}
        public virtual List<Comment> Comments { get; set;}
    }
}
