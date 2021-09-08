using Domain.Models;
using System;

namespace Repository.Repository
{
    public interface IUserRepository : IGenericRepository<User, Guid>
    {
    }
}
