using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQuery : IRequest<List<CommentVM>>
    {
    }
}
