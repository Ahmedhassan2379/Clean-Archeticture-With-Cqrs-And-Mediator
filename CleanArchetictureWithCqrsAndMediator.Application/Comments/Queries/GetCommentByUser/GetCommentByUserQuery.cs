using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentByUser
{
    public class GetCommentByUserQuery : IRequest<CommentVM>
    {
        public string UserName { get; set; }
    }
}
