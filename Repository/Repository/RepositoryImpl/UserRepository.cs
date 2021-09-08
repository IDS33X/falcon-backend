using Domain.Models;
using Repository.Context;
using Repository.RepositoryImpl;
using System;

namespace Repository.Repository.RepositoryImpl
{
    public class UserRepository : GenericRepository<User, Guid>, IUserRepository
    {
        public UserRepository(FalconDBContext context) : base(context)
        {

        }
    }
}
