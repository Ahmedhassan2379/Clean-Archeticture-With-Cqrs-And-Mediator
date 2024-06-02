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

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repository;
        public UpdateBlogCommandHandler(IMapper mapper, IBlogRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var updateBlog = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Author = request.Author
            };
            return await _repository.UpdateBlog(updateBlog.Id,updateBlog);
        }
    }
}
