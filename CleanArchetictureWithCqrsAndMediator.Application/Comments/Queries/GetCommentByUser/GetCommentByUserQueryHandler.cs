using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentByUser
{
    public class GetCommentByUserQueryHandler : IRequestHandler<GetCommentByUserQuery, CommentVM>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        public GetCommentByUserQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommentVM> Handle(GetCommentByUserQuery request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetCommentsByUser(request.UserName);
            var result = _mapper.Map<CommentVM>(comment);
            return result;
        }
    }
}
