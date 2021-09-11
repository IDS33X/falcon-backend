using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Department;
using Util.Support.Responses;
using Util.Support.Responses.Department;

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
        public async Task<AddDepartmentResponse> Add(AddDepartmentRequest request)
        {
            var department = _mapper.Map<Department>(request.Department);

            department = await _unitOfWork.Departments.Add(department);

            await _unitOfWork.CompleteAsync();

            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return new AddDepartmentResponse { Department = departmentDto };
        }

        public async Task<DepartmentsByDivisionResponse> GetDepartmentsByDivision(DepartmentsByDivisionRequest request)
        {
            var departments = await _unitOfWork.Departments.GetDepartmentsByDivision(request.DivisionId, request.Page, request.ItemsPerPage);

            List<DepartmentDto> departmentDtos = new List<DepartmentDto>();

            foreach (Department department in departments)
            {
                var departmentDto = _mapper.Map<DepartmentDto>(department);

                departmentDto.CountAnalytics = await _unitOfWork.UserProfiles.GetUsersByDepartmentCount(departmentDto.Id);

                departmentDtos.Add(departmentDto);
            }

            int departmentsByDivisionCount = await _unitOfWork.Departments.GetDepartmentsByDivisionCount(request.DivisionId);
            int pages = Convert.ToInt32(Math.Ceiling((double)departmentsByDivisionCount / request.ItemsPerPage));

            DepartmentsByDivisionResponse response = new DepartmentsByDivisionResponse
            {
                AmountOfPages = pages,
                CurrentPage = departmentDtos.Count > 0 ? request.Page : 0,
                Departments = departmentDtos
            };

            return response;
        } 
        public async Task<DepartmentsByDivisionSearchResponse> GetDepartmentsByDivisionAndSearch(DepartmentsByDivisionSearchRequest request)
        {
            var departments = await _unitOfWork.Departments.GetDepartmentsByDivisionSearch(request.DivisionId, request.Filter, request.Page, request.ItemsPerPage);

            List<DepartmentDto> departmentDtos = new List<DepartmentDto>();

            foreach (Department department in departments)
            {
                var departmentDto = _mapper.Map<DepartmentDto>(department);

                departmentDto.CountAnalytics = await _unitOfWork.UserProfiles.GetUsersByDepartmentCount(departmentDto.Id);

                departmentDtos.Add(departmentDto);
            }

            int departmentsByDivisionAndSearchCount = await _unitOfWork.Departments.GetDepartmentsByDivisionSearchCount(request.DivisionId, request.Filter);
            int pages = Convert.ToInt32(Math.Ceiling((double)departmentsByDivisionAndSearchCount / request.ItemsPerPage));

            DepartmentsByDivisionSearchResponse response = new DepartmentsByDivisionSearchResponse
            {
                AmountOfPages = pages,
                CurrentPage = departmentDtos.Count > 0 ? request.Page : 0,
                Departments = departmentDtos
            };

            return response;
        }

        public async Task<DepartmentDto> GetById(int id)
        {
            var department = await _unitOfWork.Departments.GetById(id);

            var departmentDto = _mapper.Map<DepartmentDto>(department);

            departmentDto.CountAnalytics = await _unitOfWork.UserProfiles.GetUsersByDepartmentCount(departmentDto.Id);

            return departmentDto;
        }

        public async Task<bool> Removed(int id)
        {
            var isRemoved = await _unitOfWork.Departments.Removed(id);
            await _unitOfWork.CompleteAsync();

            return isRemoved;
        }

        public async Task<EditDepartmentResponse> Update(EditDepartmentRequest request)
        {
            var department = _mapper.Map<Department>(request.Department);

            var departmentUpdated = await _unitOfWork.Departments.Update(department);
            var departmentUpdatedDto = _mapper.Map<DepartmentDto>(departmentUpdated);
            await _unitOfWork.CompleteAsync();

            return new EditDepartmentResponse { Department = departmentUpdatedDto };
        }
    }
}
