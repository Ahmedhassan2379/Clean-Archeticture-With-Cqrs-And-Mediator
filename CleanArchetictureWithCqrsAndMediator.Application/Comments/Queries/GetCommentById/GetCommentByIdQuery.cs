using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQuery  :IRequest<CommentVM>
    {
        public int commentId { get; set; }
    }
}
