using Domain.Models;
using Repository.Context;
using Repository.RepositoryImpl;
using System;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryImpl
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        public UserRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<User> ChangePassword(User user)
        {
            await Task.Run(() =>
            {
                context.Set<User>().Attach(user);
                context.Entry(user).Property(u => u.Password).IsModified = true;
            });

            return user;
        }  
    }
}
