using System.Threading.Tasks;
using Repository.Context;
using Repository.Repository;
using Repository.Repository.RepositoryImpl;
using Repository.UnitOfWork;

namespace Repository.UnitOfWorkImpl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FalconDBContext context;
 
        public IUserProfileRepository UserProfiles {get;}
        public IUserRepository Users { get; }
        public IAreaRepository Areas { get; }
        public IDivisionRepository Divisions { get; }
        public IDepartmentRepository Departments { get; }
        public IMRoleRepository MRoles { get; }

        public UnitOfWork(FalconDBContext context){
            this.context = context;
            
            UserProfiles = new UserProfileRepository(context);
            Users = new UserRepository(context);
            Areas = new AreaRepository(context);
            Divisions = new DivisionRepository(context);
            Departments = new DepartmentRepository(context);
            MRoles = new MRoleRepository(context);
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}