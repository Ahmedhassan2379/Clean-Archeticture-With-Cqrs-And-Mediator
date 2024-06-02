using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Commands.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repository;
        public DeleteBlogCommandHandler(IMapper mapper, IBlogRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.DeleteBlog(request.BlogId);
            return blog;
        }
    }
}
