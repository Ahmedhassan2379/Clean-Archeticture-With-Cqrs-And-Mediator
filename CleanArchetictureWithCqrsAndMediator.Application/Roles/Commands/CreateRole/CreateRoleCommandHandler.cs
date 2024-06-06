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

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, RoleVM>
    {
        private readonly IMapper _mapper;
        private readonly IRolesRepository _repository;
        public CreateRoleCommandHandler(IMapper mapper, IRolesRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<RoleVM> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role {  Name = request.Name};
            var result = await _repository.CreateRole(role);
            return _mapper.Map<RoleVM>(result);
        }
    }
}
