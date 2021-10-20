using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Support.Responses.MControlState;

namespace Service.Service
{
    public interface IMControlStateService
    {
        Task<GetControlStatesResponse> GetAll();
    }
}
