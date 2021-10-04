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
    public class MControlStateRepository : GenericRepository<MControlState,int>, IMControlStateRepository
    {

        public MControlStateRepository(FalconDBContext context) : base(context)
        {

        }

    }
}
