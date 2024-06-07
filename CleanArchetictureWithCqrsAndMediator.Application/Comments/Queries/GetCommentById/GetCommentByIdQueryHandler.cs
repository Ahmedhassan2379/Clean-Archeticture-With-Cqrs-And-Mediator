using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentById
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentVM>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        public GetCommentByIdQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommentVM> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetCommentsById(request.commentId);
            var result = _mapper.Map<CommentVM>(comment);
            return result;
        }
    }
}
