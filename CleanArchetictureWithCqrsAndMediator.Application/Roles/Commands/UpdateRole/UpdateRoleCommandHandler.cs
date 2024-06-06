using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRolesRepository _repository;
        public UpdateRoleCommandHandler(IMapper mapper, IRolesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var updateRole = new Role()
            {
                Id = request.Id,
                Name = request.Name
            };
            return await _repository.UpdateRole(updateRole.Id, updateRole);
        }
    }
}
