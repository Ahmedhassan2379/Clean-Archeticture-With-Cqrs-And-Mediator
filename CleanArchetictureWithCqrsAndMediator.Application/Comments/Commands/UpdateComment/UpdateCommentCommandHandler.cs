using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _repository;
        public UpdateCommentCommandHandler(IMapper mapper, ICommentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var updateComment = new Comment()
            {
                Id = request.Id,
                Content = request.Content,
                CreatedDate = request.CreatedDate,
                UpdatedDate = request.UpdatedDate,
                User = new User() { Email = request.User.Email,Password=request.User.Password,Id = request.User.Id,UserName = request.User.UserName},
                Blog = new Blog() {Author = request.Blog.Author,Name=request.Blog.Name,Description=request.Blog.Description,Id = request.Blog.Id }
            };
            return await _repository.UpdateComment(updateComment.Id, updateComment);
        }
    }
}
