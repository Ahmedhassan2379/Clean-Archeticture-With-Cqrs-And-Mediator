using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public DeleteUserCommandHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.DeleteUser(request.UserId);
            return user;
        }
    }
}
