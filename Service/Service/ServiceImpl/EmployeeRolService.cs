using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.EmployeeRol;
using Util.Support.Responses.EmployeeRol;

namespace Service.Service.ServiceImpl
{
    public class EmployeeRolService : IEmployeeRolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeRolService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetEmployeeRolsResponse> GetAll(GetEmployeeRolsRequest request)
        {
            var employeeRols = await _unitOfWork.EmployeeRols.GetAll();

            List<EmployeeRolDto> employeeRolDtos = new List<EmployeeRolDto>();

            foreach (EmployeeRol employeeRol in employeeRols)
            {
                var employeeRolDto = _mapper.Map<EmployeeRolDto>(employeeRol);

                employeeRolDtos.Add(employeeRolDto);
            }

            return new GetEmployeeRolsResponse { EmployeeRols = employeeRolDtos };
        }
    }
}
