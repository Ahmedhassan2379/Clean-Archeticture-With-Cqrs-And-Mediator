using CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Queries.GetAllRoles
{
    public class GetAllRolesQuery:IRequest<List<RoleVM>>
    {
    }
}
