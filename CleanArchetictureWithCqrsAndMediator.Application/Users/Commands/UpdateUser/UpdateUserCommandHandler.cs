using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public UpdateUserCommandHandler(IMapper mapper, IUserRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {

            var updateUser = new User()
            {
                Id = request.Id,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                Role = new Role() { Name = request.Role.Name, Id = request.Role.Id }
            };
            return await _repository.UpdateUser(updateUser.Id, updateUser);
        }
    }
}
