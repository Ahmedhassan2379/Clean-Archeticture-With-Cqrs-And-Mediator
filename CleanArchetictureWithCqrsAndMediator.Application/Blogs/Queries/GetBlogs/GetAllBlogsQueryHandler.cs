using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Blogs.Queries.GetBlogs
{
    public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, List<BlogVM>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        public GetAllBlogsQueryHandler(IBlogRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<BlogVM>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
           var blogs =  await _repository.GetAllBlogs();
            var result = blogs.Select(b => new BlogVM
            {
                Author = b.Author,
                Description = b.Description,
                BlogName = b.Name,
                Id = b.Id,
                UserName = b.User.UserName,
                Comments =  b.Comments.Select(x=>new Comment { Content=x.Content}).ToList() ,
            }).ToList();
            //var result = _mapper.Map<List<BlogVM>>(blogs);
            return result;
        }
    }
}
