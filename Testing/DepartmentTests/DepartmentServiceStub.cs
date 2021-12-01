using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Service;
using Util.Dtos.DepartmentDtos;
using Util.Support.Requests.Department;
using Util.Support.Responses.Department;
using Domain.Models;
using AutoMapper;
using Util.Mappings;

namespace Testing.DepartmentTests
{
    public class DepartmentServiceStub : IDepartmentService
    {
        private static List<Department> departments = new List<Department>();
        private static int departmentsCount = 0;

        private readonly IMapper _mapper;

        public DepartmentServiceStub()
        {
            _mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            departments.Clear();
        }
        public Task<AddDepartmentResponse> Add(AddDepartmentRequest request)
        {
            departmentsCount++;
            var department = _mapper.Map<Department>(request.Department);
            department.Id = departmentsCount;

            departments.Add(department);

            var departmentDto = _mapper.Map<DepartmentReadDto>(department);

            return Task.FromResult(new AddDepartmentResponse() { Department=departmentDto });
        }

        public Task<DepartmentReadDto> GetById(int id)
        {
            var department = departments.Where(d => d.Id == id).FirstOrDefault();

            var departmentDto = _mapper.Map<DepartmentReadDto>(department);

            return Task.FromResult(departmentDto);
        }

        public Task<DepartmentsByDivisionResponse> GetDepartmentsByDivision(DepartmentsByDivisionRequest request)
        {
            var departmentsDto = new List<DepartmentReadDto>();

            foreach (var dep in departments)
            {
                if (dep.DivisionId == request.DivisionId)
                {
                    var departmentDto = _mapper.Map<DepartmentReadDto>(dep);
                    departmentsDto.Add(departmentDto);
                }
            }

            return Task.FromResult(new DepartmentsByDivisionResponse() { Departments = departmentsDto });
        }

        public Task<DepartmentsByDivisionSearchResponse> GetDepartmentsByDivisionAndSearch(DepartmentsByDivisionSearchRequest request)
        {
            var departmentsDto = new List<DepartmentReadDto>();

            foreach (var dep in departments)
            {
                if (dep.DivisionId == request.DivisionId && dep.Title.Contains(request.Filter))
                {
                    var departmentDto = _mapper.Map<DepartmentReadDto>(dep);
                    departmentsDto.Add(departmentDto);
                }
            }

            return Task.FromResult(new DepartmentsByDivisionSearchResponse() { Departments = departmentsDto });
        }

        public Task<bool> Removed(int id)
        {
            var dep = departments.Where(d => d.Id == id).FirstOrDefault();

            if (dep != null)
            {
                departments.Remove(dep);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<EditDepartmentResponse> Update(EditDepartmentRequest request)
        {
            var dep = _mapper.Map<Department>(request.Department);

            var update = departments.Where(d => d.Id == request.Department.Id).FirstOrDefault();

            update = dep;

            var updatedDep = _mapper.Map<DepartmentReadDto>(update);

            return Task.FromResult(new EditDepartmentResponse() { Department =updatedDep });
        }

        //Static Methods
        public static void clearDatabase()
        {
            departments.Clear();
            departmentsCount = 0;
        }

        public static void AddRange(List<Department> fakesDepartments)
        {
            departments.AddRange(fakesDepartments);
        }
    }
}
