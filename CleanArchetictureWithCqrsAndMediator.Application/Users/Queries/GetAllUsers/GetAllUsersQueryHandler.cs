using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,List<UserVM>>    
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<List<UserVM>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllUsers();
            //var result =  blogs.Select(b => new BlogVM
            // {
            //     Author = b.Author,
            //     Description = b.Description,
            //     Name = b.Name,
            //     Id = b.Id,
            // }).ToList();
            var result = _mapper.Map<List<UserVM>>(users);
            return result;
        }
    }
}
