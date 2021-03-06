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
        IRiskCategoryRepository RiskCategories { get; }
        IRiskImpactRepository RiskImpacts { get; }
        IRiskRepository Risks { get; }
        IControlRepository Controls { get; }
        IMAutomationLevelRepository AutomationLevels { get; }
        IMControlStateRepository ControlStates { get; }
        IMControlTypeRepository ControlTypes { get;  }

        IRiskControlRepository RiskControls { get; }

        IUserControlRepository UserControls { get; }

        Task CompleteAsync();
    }
}