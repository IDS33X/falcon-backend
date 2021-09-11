using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> Add(UserProfile user);
        Task<UserProfile> FindByCode(string code);
        Task<UserProfile> FindByUsername(string username);
        Task<UserProfile> GetById(int id);
        Task<IEnumerable<UserProfile>> GetUsersByDepartment(int departmentId, int page, int perPage);
        Task<int> GetUsersByDepartmentCount(int departmentId);
        Task<IEnumerable<UserProfile>> GetUsersByDepartmentSearch(int departmentId, string filter, int page, int perPage);
        Task<int> GetUsersByDepartmentSearchCount(int departmentId, string filter);
        Task<UserProfile> Update(UserProfile user);
    }
}
