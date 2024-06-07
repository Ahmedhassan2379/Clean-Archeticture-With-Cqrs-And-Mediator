using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Comments.Commands.CreateComment;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Comments.Queries.GetAllComments
{
    public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery,List<CommentVM>>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        public GetAllCommentsQueryHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CommentVM>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await _repository.GetAllComments();
            //var result =  blogs.Select(b => new BlogVM
            // {
            //     Author = b.Author,
            //     Description = b.Description,
            //     Name = b.Name,
            //     Id = b.Id,
            // }).ToList();
            var result = _mapper.Map<List<CommentVM>>(comments);
            return result;
        }
    }
}
