using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
