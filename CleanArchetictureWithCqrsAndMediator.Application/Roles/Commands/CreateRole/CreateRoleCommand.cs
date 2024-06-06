using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand :IRequest<RoleVM>
    {
        public string? Name { get; set; }

    }
}
