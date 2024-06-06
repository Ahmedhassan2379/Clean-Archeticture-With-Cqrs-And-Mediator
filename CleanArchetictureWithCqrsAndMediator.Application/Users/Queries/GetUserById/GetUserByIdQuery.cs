using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserVM>
    {
        public int UserId { get; set; }
    }
}
