using System.Threading.Tasks;
using Repository.Context;
using Repository.Repository;
using Repository.Repository.RepositoryImpl;
using Repository.UnitOfWork;

namespace Repository.UnitOfWorkImpl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FalconDBContext _context;
 
        public IUserProfileRepository UserProfiles {get;}
        public IUserRepository Users { get; }
        public IAreaRepository Areas { get; }
        public IDivisionRepository Divisions { get; }
        public IDepartmentRepository Departments { get; }
        public IMRoleRepository MRoles { get; }
        public IRiskCategoryRepository RiskCategories { get; }
        public IRiskImpactRepository RiskImpacts { get; }
        public IRiskRepository Risks { get; }

        public UnitOfWork(FalconDBContext context){
            this._context = context;
            
            UserProfiles = new UserProfileRepository(context);
            Users = new UserRepository(context);
            Areas = new AreaRepository(context);
            Divisions = new DivisionRepository(context);
            Departments = new DepartmentRepository(context);
            MRoles = new MRoleRepository(context);
            RiskCategories = new RiskCategoryRepository(context);
            RiskImpacts = new RiskImpactRepository(context);
            Risks = new RiskRepository(context);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}