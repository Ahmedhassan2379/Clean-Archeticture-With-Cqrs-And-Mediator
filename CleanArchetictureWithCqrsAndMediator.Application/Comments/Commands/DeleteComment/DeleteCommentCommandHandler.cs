using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _repository;
        public DeleteCommentCommandHandler(IMapper mapper, ICommentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.DeleteComment(request.CommentId);
            return comment;
        }
    }
}
