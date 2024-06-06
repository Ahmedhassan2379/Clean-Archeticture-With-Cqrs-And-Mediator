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
        public async Task<Comment> CreateBlog(Comment comment)
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

        public async Task<List<Comment>> GetCommentsByBlog(int id)
        {
            var comment = await _dbcontext.Comments.AsNoTracking().Where(x => x.Blog.Id == id).ToListAsync();
            return comment;
        }

        public async Task<Comment> GetCommentsById(int id)
        {
            var comment = await _dbcontext.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return comment;
        }

        public async Task<List<Comment>> GetCommentsByUser(int id)
        {
            var comment = await _dbcontext.Comments.AsNoTracking().Where(x => x.User.Id == id).ToListAsync();
            return comment;
        }

        public async Task<int> UpdateComment(int Id, Comment comment)
        {
            return await _dbcontext.Comments.Where(x => x.Id == Id)
                .ExecuteUpdateAsync(setter => setter
                .SetProperty(m => m.Content, comment.Content)
                .SetProperty(m => m.CreatedDate, comment.CreatedDate)
                .SetProperty(m => m.UpdatedDate, comment.UpdatedDate));
        }
    }
}
