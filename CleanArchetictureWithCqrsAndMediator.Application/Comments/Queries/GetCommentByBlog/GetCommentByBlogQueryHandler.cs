using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetCommentByBlog
{
    public class GetCommentByBlogQueryHandler : IRequestHandler<GetCommentByBlogQuery, CommentVM>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        public GetCommentByBlogQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommentVM> Handle(GetCommentByBlogQuery request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetCommentsByBlog(request.BlogName);
            var result = _mapper.Map<CommentVM>(comment);
            return result;
        }
    }
}
