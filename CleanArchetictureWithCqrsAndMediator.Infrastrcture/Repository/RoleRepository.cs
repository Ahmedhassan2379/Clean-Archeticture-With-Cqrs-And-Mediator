using CleanArchetictureWithCqrsAndMediator.Domain.Entities;
using CleanArchetictureWithCqrsAndMediator.Domain.Repository;
using CleanArchetictureWithCqrsAndMediator.Infrastrcture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchetictureWithCqrsAndMediator.Infrastrcture.Repository
{
    public class RoleRepository : IRolesRepository
    {
        private readonly BlogDbContext _dbcontext;
        public RoleRepository(BlogDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<Role> CreateRole(Role role)
        {
            await _dbcontext.Roles.AddAsync(role);
            await _dbcontext.SaveChangesAsync();
            return role;
        }

        public async Task<int> DeleteRole(int id)
        {
            return await _dbcontext.Roles.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _dbcontext.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            var role = await _dbcontext.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return role;
        }

        public async Task<Role> GetRoleByName(string name)
        {
            var role = await _dbcontext.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
            return role;
        }

        public async Task<int> UpdateRole(int Id, Role role)
        {
            return await _dbcontext.Roles.Where(x => x.Id == Id)
               .ExecuteUpdateAsync(setter => setter
               .SetProperty(m => m.Name, role.Name));
        }
    }
}
