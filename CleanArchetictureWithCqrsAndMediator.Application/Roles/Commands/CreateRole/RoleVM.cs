using CleanArchetictureWithCqrsAndMediator.Application.Common.Mappings;
using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Application.Roles.Commands.CreateRole
{
    public class RoleVM : IMapForm<Role>
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
