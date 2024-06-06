using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Domain.Repository
{
    public interface IRolesRepository
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<Role> GetRoleByName(string name);
        Task<Role> CreateRole(Role role);
        Task<int> UpdateRole(int Id, Role role);
        Task<int> DeleteRole(int id);
    }
}
