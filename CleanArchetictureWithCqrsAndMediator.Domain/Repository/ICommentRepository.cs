using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Domain.Repository
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComments();
        Task<Comment> GetCommentsById(int id);
        Task<List<Comment>> GetCommentsByBlog(string Name);
        Task<List<Comment>> GetCommentsByUser(string Name);
        Task<Comment> CreateComment(Comment comment);
        Task<int> UpdateComment(int Id, Comment comment);
        Task<int> DeleteComment(int id);
    }
}
