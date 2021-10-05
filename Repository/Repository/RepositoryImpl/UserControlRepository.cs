using Domain.Models;
using Repository.Context;
using Repository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.RepositoryImpl
{
    public class UserControlRepository : GenericRepository<UserControl, int>, IUserControlRepository
    {
        public UserControlRepository(FalconDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<UserControl>> AddRange(IEnumerable<UserControl> userControls)
        {
            await context.Set<UserControl>().AddRangeAsync(userControls);
            return userControls;
        }

        public async Task<IEnumerable<UserControl>> UpdateRange(IEnumerable<UserControl> userControls)
        {
            await Task.Run(() => context.Set<UserControl>().UpdateRange(userControls));
            return userControls;
        }
    }
}
