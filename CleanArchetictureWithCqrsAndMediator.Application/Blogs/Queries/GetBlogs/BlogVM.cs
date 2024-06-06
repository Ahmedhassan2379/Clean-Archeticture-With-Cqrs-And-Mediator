using CleanArchetictureWithCqrsAndMediator.Application.Common.Mappings;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs
{
    public class BlogVM : IMapForm<Blog>
    {
        public int Id { get; set; }
        public string? BlogName { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public string? UserName { get; set; }
        public List<Comment>? Comments { get; set;}
    }
}
