using AutoMapper;
using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Queries.GetRoleByName
{
    public class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, RoleVM>
    {
        private readonly IMapper _mapper;
        private readonly IRolesRepository _repository;
        public GetRoleByNameQueryHandler(IRolesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoleVM> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            var role = await _repository.GetRoleByName(request.RoleName);
            var result = _mapper.Map<RoleVM>(role);
            return result;
        }
    }
}
