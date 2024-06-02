using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using CleanArchetictureWithCqrsAndMediator.Infrastrcture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Infrastrcture.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _dbcontext;
        public BlogRepository(BlogDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<Blog> CreateBlog(Blog blog)
        {
             await _dbcontext.Blogs.AddAsync(blog);
           await _dbcontext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteBlog(int id)
        {
            return await _dbcontext.Blogs.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            return await _dbcontext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetBlogById(int id)
        {
            var blog = await _dbcontext.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return blog;
        }

        public async Task<int> UpdateBlog(int Id, Blog blog)
        {
            return await _dbcontext.Blogs.Where(x => x.Id == Id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(m => m.Name, blog.Name)
                .SetProperty(m => m.Description, blog.Description)
                .SetProperty(m => m.Author, blog.Author));
        }
    }
}
