using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IUserControlRepository: IGenericRepository<UserControl,int>
    {
        Task<(IEnumerable<UserControl> usersControlsAdded, IEnumerable<(UserControl userControl, string errorMessage)> usersControlsNotAdded)> AddRange(IEnumerable<UserControl> userControls);
        Task<(IEnumerable<UserControl> userControlsRemoved, IEnumerable<(UserControl userControl, string errorMessage)> userControlsNotRemoved)> UpdateRange(IEnumerable<UserControl> userControls);
    }
}
