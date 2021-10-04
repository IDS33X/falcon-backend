using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IUserControlRepository: IGenericRepository<UserControl,int>
    {

        Task<IEnumerable<UserControl>> AddRange(IEnumerable<UserControl> userControls);

        Task<IEnumerable<UserControl>> UpdateRange(IEnumerable<UserControl> userControls);

    }
}
