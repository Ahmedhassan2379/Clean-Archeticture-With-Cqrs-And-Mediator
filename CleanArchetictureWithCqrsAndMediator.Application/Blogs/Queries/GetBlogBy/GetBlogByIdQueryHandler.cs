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

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogBy
{
    public class GetBlogByIdQueryHandler :IRequestHandler<GetBlogByIdQuer,BlogVM>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _repository;
        public GetBlogByIdQueryHandler(IBlogRepository repository , IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }

        public async Task<BlogVM> Handle(GetBlogByIdQuer request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetBlogById(request.blogId);
            var result = _mapper.Map<BlogVM>(blog);
            return result;
        }
    }
}
