using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommand : IRequest<int>
    {
        public int BlogId { get; set; }
    }
}
