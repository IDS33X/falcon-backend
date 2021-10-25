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
    public class RiskControlRepository : GenericRepository<RiskControl,int> , IRiskControlRepository
    {
        public RiskControlRepository(FalconDBContext context): base(context)
        {

        }

        public new async Task<RiskControl> Add(RiskControl riskControl)
        {
            var riskControlEntity = context.Set<RiskControl>();

            var riskControlExist = await riskControlEntity
                .Where(rc => rc.ControlId == riskControl.ControlId && rc.RiskId == riskControl.RiskId)
                .FirstOrDefaultAsync();

            if (riskControlExist != null && riskControlExist.DeallocatedDate == null)
            {
                throw new AlreadyExistException("An risk control with the provided riskId and controlId is already active");
            }
            else if (riskControlExist != null && riskControlExist.DeallocatedDate != null)
            {
                riskControlExist.DeallocatedDate = null;
                riskControlExist.AssignDate = DateTime.Now;

                await Task.Run(() => riskControlEntity.Update(riskControlExist));

                return riskControlExist;
            }

            await riskControlEntity.AddAsync(riskControl);

            return riskControl;

        }

        public async Task<(IEnumerable<RiskControl> riskControlsAdded, IEnumerable<(RiskControl riskControl, string errorMessage)> riskControlsNotAdded)> AddRange(IEnumerable<RiskControl> risksControls)
        {
            var riskControlDbSet = context.Set<RiskControl>();

            List<RiskControl> risksControlsToAdd = new List<RiskControl>();
            List<RiskControl> risksControlsToModify = new List<RiskControl>();
            List<(RiskControl,string)> riskControlsNotAdded = new List<(RiskControl, string)>();

            foreach (RiskControl riskControl in risksControls)
            {
                var riskControlExist = await riskControlDbSet
                    .Where(rc => rc.ControlId == riskControl.ControlId && rc.RiskId == riskControl.RiskId)
                    .FirstOrDefaultAsync();

                if (riskControlExist == null)
                {
                    var riskExist = await context.Set<Risk>().FindAsync(riskControl.RiskId);
                    var controlExist = await context.Set<Control>().FindAsync(riskControl.ControlId);

                    if (riskExist == null && controlExist == null)
                    {
                        riskControlsNotAdded.Add((riskControl, "Risk and control not found"));
                    }
                    else if (riskExist == null)
                    {
                        riskControlsNotAdded.Add((riskControl, "Risk not found"));
                    }
                    else if (controlExist == null)
                    {
                        riskControlsNotAdded.Add((riskControl, "Control not found"));
                    }
                    else
                    {
                        risksControlsToAdd.Add(riskControl);
                    }
                }
                else
                {
                    if (riskControlExist.DeallocatedDate != null)
                    {
                        riskControlExist.DeallocatedDate = null;
                        riskControlExist.AssignDate = DateTime.Now;

                        risksControlsToModify.Add(riskControlExist);
                    }
                    else
                    {
                        riskControlsNotAdded.Add((riskControl, "Risk control already active"));
                    }
                }
            }

            await riskControlDbSet.AddRangeAsync(risksControlsToAdd);
            await Task.Run(() => riskControlDbSet.UpdateRange(risksControlsToModify));

            risksControlsToAdd.AddRange(risksControlsToModify);

            return (risksControlsToAdd, riskControlsNotAdded);
        }

        public async Task<(IEnumerable<RiskControl> riskControlsRemoved, IEnumerable<(RiskControl riskControl, string errorMessage)> riskControlsNotRemoved)> UpdateRange(IEnumerable<RiskControl> risksControls)
        {
            var riskControlDbSet = context.Set<RiskControl>();

            List<RiskControl> risksControlsToRemove = new List<RiskControl>();
            List<(RiskControl, string)> riskControlsNotRemoved = new List<(RiskControl, string)>();

            foreach (RiskControl riskControl in risksControls)
            {
                var riskControlBeforeRemove = await context.Set<RiskControl>()
                                                           .Where(rc => rc.ControlId == riskControl.ControlId && rc.RiskId == riskControl.RiskId)
                                                           .FirstOrDefaultAsync();

                if (riskControlBeforeRemove == null)
                {
                    riskControlsNotRemoved.Add((riskControl, "Risk control not found"));
                }
                else if (riskControlBeforeRemove.DeallocatedDate != null)
                {
                    riskControlsNotRemoved.Add((riskControl, "Risk control is already deactivated"));
                }
                else
                {
                    riskControlBeforeRemove.DeallocatedDate = DateTime.Now;
                    risksControlsToRemove.Add(riskControlBeforeRemove);
                }
            }

            await Task.Run(() => context.Set<RiskControl>().UpdateRange(risksControlsToRemove));
            return (risksControlsToRemove, riskControlsNotRemoved);
        }

        public new async Task<RiskControl> Update(RiskControl riskControl)
        {
            var riskControlBeforeRemove = await context.Set<RiskControl>()
                                                       .Where(rc => rc.ControlId == riskControl.ControlId && rc.RiskId == riskControl.RiskId)
                                                       .FirstOrDefaultAsync();

            if (riskControlBeforeRemove == null)
            {
                throw new DoesNotExistException("Risk control not found");
            }

            if (riskControlBeforeRemove.DeallocatedDate != null)
            {
                throw new AlreadyExistException("Risk control already deactivated");
            }

            riskControlBeforeRemove.DeallocatedDate = DateTime.Now;

            await Task.Run(() =>
            {
                context.Set<RiskControl>().Attach(riskControlBeforeRemove);
                context.Entry(riskControlBeforeRemove).Property(rc => rc.DeallocatedDate).IsModified = true;
            });

            return riskControlBeforeRemove;
        }
    }
}
