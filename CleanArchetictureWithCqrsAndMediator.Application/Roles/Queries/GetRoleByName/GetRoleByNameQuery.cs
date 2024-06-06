using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Queries.GetRoleByName
{
    public class GetRoleByNameQuery : IRequest<RoleVM>
    {
        public string RoleName { get; set; } = "User";
    }
}
