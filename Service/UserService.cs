using entities;
using Repository;
using System.Text.Json;
using Zxcvbn;


namespace Service
{
    public class UserService : IUserService
    {
        IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<User> loginAsync(User user)
        {
            return await repository.foundUserAsync(user);
        }

        public async Task<User> registerAsync(User user)
        {
            if (!await repository.existEmailAsync(user.Email))
            {
                return await repository.addUserAsync(user);
            }
            return null;
        }

        public async Task updateAsync(User user, int id)
        {
            await repository.updateUserAsync(user, id);
        }

        public async Task<User> getbyIdAsync(int id)
        {
            return await repository.getUserAsync(id);
        }



    }
}