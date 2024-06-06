using CleanArchetictureWithCqrsAndMediator.Application.Common.Mappings;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Users.Commands.CreateUser
{
    public class UserVM : IMapForm<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; } = "User";
    }
}
