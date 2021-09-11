using System.Threading.Tasks;
using Repository.Repository;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAreaRepository Areas { get; }
        IDivisionRepository Divisions { get; }
        IDepartmentRepository Departments { get; }
        IUserRepository Users { get; }
        IUserProfileRepository UserProfiles { get; }
        IMRoleRepository MRoles { get; }

        Task CompleteAsync();
    }
}