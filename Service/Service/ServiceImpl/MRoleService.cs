using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.MRole;
using Util.Support.Requests.MRole;
using Util.Support.Responses.MRole;

namespace Service.Service.ServiceImpl
{
    public class MRoleService : IMRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MRoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetMRolesResponse> GetAll(GetMRolesRequest request)
        {
            var roles = await _unitOfWork.MRoles.GetAll();

            List<MRoleDto> roleDtos = new List<MRoleDto>();

            foreach (MRole role in roles)
            {
                var roleDto = _mapper.Map<MRoleDto>(role);

                roleDtos.Add(roleDto);
            }

            return new GetMRolesResponse { Roles = roleDtos };
        }
    }
}
