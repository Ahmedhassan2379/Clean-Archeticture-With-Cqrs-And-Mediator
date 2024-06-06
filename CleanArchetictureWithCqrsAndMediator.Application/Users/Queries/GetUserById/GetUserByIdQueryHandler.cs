using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserVM>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public GetUserByIdQueryHandler(IUserRepository repository,IMapper mapper)
        {
                _repository = repository;
                _mapper = mapper;
        }
        public async Task<UserVM> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetUserById(request.UserId);
            var result = _mapper.Map<UserVM>(user);
            return result;
        }
    }
}
