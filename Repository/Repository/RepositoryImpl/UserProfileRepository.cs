using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Repository.Repository.RepositoryImpl
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly FalconDBContext _context;
        public UserProfileRepository(FalconDBContext dBContext)
        {
            _context = dBContext;
        }
        public async Task<UserProfile> Add(UserProfile user)
        {
            var userWithThatCode = await _context.UserProfile.Where(up => up.Code == user.Code)
                                                             .FirstOrDefaultAsync();

            if (userWithThatCode != null)
            {
                throw new AlreadyExistException("An user with that code already exist");
            }

            var userWithThatUsername = await _context.UserProfile.Include(up => up.User)
                                                           .Where(up => up.User.Username == user.User.Username)
                                                           .FirstOrDefaultAsync();

            if (userWithThatUsername != null)
            {
                throw new AlreadyExistException("An user with that username already exist");
            }

            user.User.Password = BCrypt.Net.BCrypt.HashPassword(user.User.Password);

            await _context.UserProfile.AddAsync(user);
            return user;
        }

        public async Task<UserProfile> Update(UserProfile user)
        {
            var userBeforeUpdate = await _context.UserProfile.Include(u => u.Department)
                                                             .Include(u => u.User)
                                                             .ThenInclude(u => u.UserRole)
                                                             .Where(u => u.Id == user.Id)
                                                             .FirstOrDefaultAsync();

            if (userBeforeUpdate == null)
            {
                throw new DoesNotExistException("Not exist");
            }

            userBeforeUpdate.LastName = user.LastName ?? userBeforeUpdate.LastName;
            userBeforeUpdate.Name = user.Name ?? userBeforeUpdate.Name;

            if (user.DepartmentId != 0 && user.DepartmentId != userBeforeUpdate.DepartmentId)
            {
                userBeforeUpdate.DepartmentId = user.DepartmentId;
                userBeforeUpdate.Department = await _context.Department.FindAsync(userBeforeUpdate.DepartmentId);
            }

            await Task.Run(() => _context.UserProfile.Update(userBeforeUpdate));
            return userBeforeUpdate;
        }

        public async Task<UserProfile> FindByCode(string code)
        {

            UserProfile user = await Task.Run(() => _context.UserProfile.Include(u => u.User)
                                                                        .ThenInclude(u => u.UserRole)
                                                                        .Where(u => u.Code == code)
                                                                        .FirstOrDefault());

            if (user == null)
            {
                throw new DoesNotExistException("El usuario no existe");
            }
            else
            {
                user.User.Password = null;
                return user;
            }
        }

        public async Task<UserProfile> Login(string username, string password)
        {
            UserProfile user = await _context.UserProfile.Include(u => u.User)
                                                         .ThenInclude(u => u.UserRole)
                                                         .Where(u => u.User.Username == username)
                                                         .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DoesNotExistException("El usuario no existe");
            }
            else
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.User.Password))
                {
                    return user;
                }
                else
                {
                    throw new IncorrectPasswordException("Contrasena incorrecta");
                }
            }
        }

        public async Task<UserProfile> FindByUsername(string username)
        {

            UserProfile user = await _context.UserProfile.Include(u => u.User)
                                                         .ThenInclude(u => u.UserRole)
                                                         .Where(u => u.User.Username == username)
                                                         .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new DoesNotExistException("El usuario no existe");
            }
            else
            {
                user.User.Password = null;
                return user;
            }
        }

        public async Task<UserProfile> GetById(int? id)
        {
            UserProfile user = await _context.UserProfile.Include(u => u.User)
                                                         .ThenInclude(u => u.UserRole)
                                                         .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new DoesNotExistException("Not exist");
            }
            else
            {
                user.User.Password = null;
                return user;
            }
        }

        public async Task<int> GetUsersByDepartmentCount(int? departmentId)
        {
            int count = await _context.UserProfile.CountAsync(u => u.DepartmentId == departmentId);
            return count;
        }
        public async Task<int> GetUsersByDepartmentSearchCount(int? departmentId, string filter)
        {
            int count = await _context.Set<UserProfile>().CountAsync(u => u.DepartmentId == departmentId && u.Name.Contains(filter));
            return count;
        }

        public async Task<IEnumerable<UserProfile>> GetUsersByDepartment(int? departmentId, int page, int perPage)
        {
            List<UserProfile> users = await _context.UserProfile
                                 .Where(u => u.DepartmentId == departmentId)
                                 .Include(u => u.User).ThenInclude(u => u.UserRole)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();

            foreach (UserProfile user in users)
            {
                user.User.Password = null;
            }

            return users;
        }
        public async Task<IEnumerable<UserProfile>> GetUsersByDepartmentSearch(int? departmentId, string filter, int page, int perPage)
        {
            List<UserProfile> users = await _context.UserProfile
                                 .Where(u => u.DepartmentId == departmentId && (u.Name + " " + u.LastName).Contains(filter))
                                 .Include(u => u.User).ThenInclude(u => u.UserRole)
                                 .Skip((page - 1) * perPage)
                                 .Take(perPage)
                                 .ToListAsync();

            foreach (UserProfile user in users)
            {
                user.User.Password = null;
            }

            return users;
        }

    }
}
