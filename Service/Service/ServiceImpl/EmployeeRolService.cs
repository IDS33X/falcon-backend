using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;

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
        public async Task<IEnumerable<EmployeeRolDto>> GetAll()
        {
            var employeeRols = await _unitOfWork.EmployeeRols.GetAll();

            List<EmployeeRolDto> employeeDtos = new List<EmployeeRolDto>();

            foreach (EmployeeRol employeeRol in employeeRols)
            {
                var employeeRolDto = _mapper.Map<EmployeeRolDto>(employeeRol);

                employeeDtos.Add(employeeRolDto);
            }

            return employeeDtos;
        }
    }
}
