using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using CleanArchetictureWithCqrsAndMediator.Infrastrcture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Infrastrcture.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _dbcontext;
        public CommentRepository(BlogDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<Comment> CreateComment(Comment comment)
        {
            await _dbcontext.Comments.AddAsync(comment);
            await _dbcontext.SaveChangesAsync();
            return comment;
        }

        public async Task<int> DeleteComment(int id)
        {
            return await _dbcontext.Comments.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _dbcontext.Comments.ToListAsync();
        }

        public async Task<List<Comment>> GetCommentsByBlog(string Name)
        {
            var comment = await _dbcontext.Comments.AsNoTracking().Where(x => x.Blog.Name == Name).ToListAsync();
            return comment;
        }

        public async Task<Comment> GetCommentsById(int id)
        {
            var comment = await _dbcontext.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return comment;
        }

        public async Task<List<Comment>> GetCommentsByUser(string Name)
        {
            var comment = await _dbcontext.Comments.AsNoTracking().Where(x => x.User.UserName ==Name).ToListAsync();
            return comment;
        }

        public async Task<int> UpdateComment(int Id, Comment comment)
        {
            var user = await _dbcontext.Users.Where(x => x.UserName == comment.User.UserName).ToListAsync();
            var blog = await _dbcontext.Blogs.Where(x=>x.Name==comment.Blog.Name).ToListAsync();
            if (user != null && blog !=null)
            {
                var result = await _dbcontext.Comments.FirstOrDefaultAsync(x => x.Id == Id);
                if (result != null)
                {
                    result.UpdatedDate = comment.UpdatedDate;
                    result.CreatedDate = comment.CreatedDate;
                    result.Content = comment.Content;
                    result.User.UserName = comment.User.UserName;
                    result.Blog.Name = comment.Blog.Name;
                    await _dbcontext.SaveChangesAsync();
                    return 1;
                }
                return default;
            }

            return default;
            //.ExecuteUpdateAsync(setter => setter
            //.SetProperty(m => m.Content, comment.Content)
            //.SetProperty(m => m.CreatedDate, comment.CreatedDate)
            //.SetProperty(m => m.UpdatedDate, comment.UpdatedDate));
        }
    }
}
