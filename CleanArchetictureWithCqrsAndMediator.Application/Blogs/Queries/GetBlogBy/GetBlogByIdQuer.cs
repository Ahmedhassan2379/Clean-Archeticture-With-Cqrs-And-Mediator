using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogBy
{
    public class GetBlogByIdQuer :IRequest<BlogVM>
    {
        public int blogId { get; set; }
    }
}
