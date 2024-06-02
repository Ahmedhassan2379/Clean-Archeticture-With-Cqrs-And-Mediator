using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllBlogs();
        Task<Blog> GetBlogById(int id);
        Task<Blog> CreateBlog(Blog blog);
        Task<int> UpdateBlog(int Id , Blog blog);
        Task<int> DeleteBlog(int id);

    }
}
