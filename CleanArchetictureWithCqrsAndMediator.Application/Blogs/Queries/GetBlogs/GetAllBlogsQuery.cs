using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs
{
    public class GetAllBlogsQuery:IRequest<List<BlogVM>>
    {
    }
}
