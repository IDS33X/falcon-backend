using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Service.Service.ServiceImpl
{
    public class DeparmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeparmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> Add(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);

            department = await _unitOfWork.Departments.Add(department);

            await _unitOfWork.CompleteAsync();

            departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAll()
        {
            var departments = await _unitOfWork.Departments.GetAll();

            List<DepartmentDto> departmentDtos = new List<DepartmentDto>();

            foreach (Department department in departments)
            {
                var departmentDto = _mapper.Map<DepartmentDto>(department);

                departmentDto.CountAnalytics = await _unitOfWork.Departments.GetAnalystCount(departmentDto.DepartmentId);

                departmentDtos.Add(departmentDto);
            }

            return departmentDtos;
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            var department = await _unitOfWork.Departments.GetById(id);

            var departmentDto = _mapper.Map<DepartmentDto>(department);

            departmentDto.CountAnalytics = await _unitOfWork.Departments.GetAnalystCount(departmentDto.DepartmentId);

            return departmentDto;
        }

        public async Task<bool> Removed(int id)
        {
            var isRemoved = await _unitOfWork.Departments.Removed(id);
            await _unitOfWork.CompleteAsync();

            return isRemoved;
        }

        public async Task<bool> Update(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);

            var isUpdated = await _unitOfWork.Departments.Update(department);
            await _unitOfWork.CompleteAsync();

            return isUpdated;
        }
    }
}
