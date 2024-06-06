using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand :IRequest<int>
    {
        public int RoleId { get; set; }
    }
}
