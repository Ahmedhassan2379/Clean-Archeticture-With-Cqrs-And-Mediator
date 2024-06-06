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
    public class UserRepository : IUserRepository
    {
        private readonly BlogDbContext _dbcontext;
        public UserRepository(BlogDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<User> CreateUser(User user)
        {
           var role = await _dbcontext.Roles.Where(x => x.Name == user.Role.Name).ToListAsync();
            if(role == null )
            {
                return null;
            }
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _dbcontext.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _dbcontext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<int> UpdateUser(int Id, User user)
        {
            var role = await _dbcontext.Roles.Where(x=>x.Name== user.Role.Name).ToListAsync();
            if(role != null )
            {
                var result = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == Id);
                if (result != null)
                {
                    result.Password = user.Password;
                    result.Email = user.Email;
                    result.UserName = user.UserName;
                    result.Role.Name = user.Role.Name;
                    await _dbcontext.SaveChangesAsync();
                    return 1;
                }
                return default;
            }
           
            return default;
            //    .ExecuteUpdateAsync(setter => setter
            //.SetProperty(m => m.UserName, user.UserName)
            //.SetProperty(m => m.Email, user.Email)
            //.SetProperty(m => m.Password, user.Password)
            //.SetProperty(m=>m.Role.Name,user.Role.Name));
        }
    }
}
