using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
        Task<User> ChangePassword(User user);
    }
}
