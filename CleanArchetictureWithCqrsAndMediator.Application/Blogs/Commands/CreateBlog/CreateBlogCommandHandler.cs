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

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.CreateBlog
{
    internal class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVM>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repository;
        public CreateBlogCommandHandler(IMapper mapper , IBlogRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BlogVM> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog { Author = request.Author, Description=request.Description,Name= request.Name };
            var result = await _repository.CreateBlog(blog);
            return _mapper.Map<BlogVM>(result);
        }
    }
}
