using CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserVM>>
    {
    }
}
