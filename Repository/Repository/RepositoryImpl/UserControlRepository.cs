using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.RepositoryImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Repository.Repository.RepositoryImpl
{
    public class UserControlRepository : GenericRepository<UserControl, int>, IUserControlRepository
    {
        public UserControlRepository(FalconDBContext context) : base(context)
        {

        }

        public new async Task<UserControl> Add(UserControl userControl)
        {
            var userControlEntity = context.Set<UserControl>();

            var userControlExist = await userControlEntity
                .Where(uc => uc.ControlId == userControl.ControlId && uc.UserId == userControl.UserId)
                .FirstOrDefaultAsync();

            if (userControlExist != null && userControlExist.DeallocatedDate == null)
            {
                throw new AlreadyExistException("An user control with the provided userId and controlId is already active");
            }
            else if (userControlExist != null && userControlExist.DeallocatedDate != null)
            {
                userControlExist.DeallocatedDate = null;
                userControlExist.AssignDate = DateTime.Now;

                await Task.Run(() => userControlEntity.Update(userControlExist));

                return userControlExist;
            }

            await userControlEntity.AddAsync(userControl);

            return userControl;
        }
        public async Task<(IEnumerable<UserControl> usersControlsAdded, IEnumerable<(UserControl userControl, string errorMessage)> usersControlsNotAdded)> AddRange(IEnumerable<UserControl> userControls)
        {
            var userControlEntity = context.Set<UserControl>();

            List<UserControl> usersControlsToAdd = new List<UserControl>();
            List<UserControl> usersControlsToModify = new List<UserControl>();
            List<(UserControl, string)> usersControlsNotAdded = new List<(UserControl, string)>();

            foreach (UserControl userControl in userControls)
            {
                var userControlExist = await userControlEntity
                    .Where(uc => uc.ControlId == userControl.ControlId && uc.UserId == userControl.UserId)
                    .FirstOrDefaultAsync();

                if (userControlExist == null)
                {
                    var userExist = await context.Set<UserProfile>().FindAsync(userControl.UserId);
                    var controlExist = await context.Set<Control>().FindAsync(userControl.ControlId);

                    if (userExist == null && controlExist == null)
                    {
                        usersControlsNotAdded.Add((userControl, "User and control not found"));
                    }
                    else if (userExist == null)
                    {
                        usersControlsNotAdded.Add((userControl, "User not found"));
                    }
                    else if (controlExist == null)
                    {
                        usersControlsNotAdded.Add((userControl, "Control not found"));
                    }
                    else
                    {
                        usersControlsToAdd.Add(userControl);
                    }
                }
                else
                {
                    if (userControlExist.DeallocatedDate != null)
                    {

                        userControlExist.DeallocatedDate = null;
                        userControlExist.AssignDate = DateTime.Now;

                        usersControlsToModify.Add(userControlExist);
                    }
                    else
                    {
                        usersControlsNotAdded.Add((userControl, "User control already active"));
                    }
                }
            }

            await userControlEntity.AddRangeAsync(usersControlsToAdd);
            await Task.Run(() => userControlEntity.UpdateRange(usersControlsToModify));

            usersControlsToAdd.AddRange(usersControlsToModify);

            return (usersControlsToAdd, usersControlsNotAdded);
        }

        public async Task<(IEnumerable<UserControl> userControlsRemoved, IEnumerable<(UserControl userControl, string errorMessage)> userControlsNotRemoved)> UpdateRange(IEnumerable<UserControl> userControls)
        {
            var userControlEntity = context.Set<UserControl>();

            List<UserControl> usersControlsToRemoved = new List<UserControl>();
            List<(UserControl, string)> usersControlsNotRemoved = new List<(UserControl, string)>();

            foreach (UserControl userControl in userControls)
            {
                var userControlBeforeRemove = await context.Set<UserControl>()
                                                           .Where(uc => uc.ControlId == userControl.ControlId && uc.UserId == userControl.UserId)
                                                           .FirstOrDefaultAsync();

                if (userControlBeforeRemove == null)
                {
                    usersControlsNotRemoved.Add((userControl, "User control not found"));
                }
                else if (userControlBeforeRemove.DeallocatedDate != null)
                {
                    usersControlsNotRemoved.Add((userControl, "User control already deactivated"));
                }
                else
                {
                    userControlBeforeRemove.DeallocatedDate = DateTime.Now;
                    usersControlsToRemoved.Add(userControlBeforeRemove);
                }
            }

            await Task.Run(() => context.Set<UserControl>().UpdateRange(usersControlsToRemoved));
            return (usersControlsToRemoved, usersControlsNotRemoved);
        }

        public new async Task<UserControl> Update(UserControl userControl)
        {
            var userControlBeforeRemove = await context.Set<UserControl>().Where(uc => uc.ControlId == userControl.ControlId && uc.UserId == userControl.UserId).FirstOrDefaultAsync();

            if (userControlBeforeRemove == null)
            {
                throw new DoesNotExistException("User control not found");
            }

            if (userControlBeforeRemove.DeallocatedDate != null)
            {
                throw new AlreadyExistException("User control already deactivated");
            }

            userControlBeforeRemove.DeallocatedDate = DateTime.Now;

            await Task.Run(() =>
            {
                context.Set<UserControl>().Attach(userControlBeforeRemove);
                context.Entry(userControlBeforeRemove).Property(u => u.DeallocatedDate).IsModified = true;
            });

            return userControlBeforeRemove;
        }
    }
}
