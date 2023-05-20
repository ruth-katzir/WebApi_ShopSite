using entities;
using System.Text.Json;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class UserRepository : IUserRepository
    {

        MyShopSite325593952Context _DbContext;

        public UserRepository(MyShopSite325593952Context dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<User> foundUserAsync(User userToSearch)
        {
            var users= await _DbContext.Users.Where(user => userToSearch.Email == user.Email && userToSearch.Password == user.Password).ToListAsync();
            if(users!=null)
                return users[0];
            return null;
        }

        public async Task<Boolean> existEmailAsync(String Email)
        {
            var users = await _DbContext.Users.Where(user => Email == user.Email).ToListAsync();
            if (users.Count > 0)
                return true;
            return false;
        }

        public async Task<User> addUserAsync(User user)
        {
            await _DbContext.Users.AddAsync(user);
            await _DbContext.SaveChangesAsync();
            return user;
        }


        public async Task updateUserAsync(User userToUpdate, int id)
        {
            _DbContext.Users.Update(userToUpdate);
            await _DbContext.SaveChangesAsync();
        }

        public async Task<User> getUserAsync(int id)
        {
            return await _DbContext.Users.FindAsync(id);
        }
    }
}