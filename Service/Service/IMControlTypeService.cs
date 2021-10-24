using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Support.Responses.MControlType;

namespace Service.Service
{
    public interface IMControlTypeService
    {
        Task<GetControlTypesResponse> GetAll();
    }
}
