using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.RepositoryImpl;

namespace Repository.Repository.RepositoryImpl
{
    class MRoleRepository : GenericRepository<MRole, int>, IMRoleRepository
    {
        public MRoleRepository(DbContext context) : base(context)
        {
        }
    }
}
