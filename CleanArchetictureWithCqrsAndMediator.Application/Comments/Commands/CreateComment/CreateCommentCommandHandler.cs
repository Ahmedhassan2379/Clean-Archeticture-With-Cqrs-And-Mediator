using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand,CommentVM>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _repository;
        public CreateCommentCommandHandler(IMapper mapper, ICommentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CommentVM> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment { Content = request.Content, CreatedDate = request.CreatedDate, UpdatedDate = request.UpdatedDate, User = new User { UserName = request.UserNmae }, Blog = new Blog { Name = request.BlogName } };
            var result = await _repository.CreateComment(comment);
            return _mapper.Map<CommentVM>(result);
        }
    }
}
