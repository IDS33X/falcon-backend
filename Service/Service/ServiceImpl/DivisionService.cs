using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Division;
using Util.Support.Responses.Division;

namespace Service.Service.ServiceImpl
{
    public class DivisionService : IDivisionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DivisionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddDivisionResponse> Add(AddDivisionRequest request)
        {
            var division = _mapper.Map<Division>(request.Division);

            division = await _unitOfWork.Divisions.Add(division);

            await _unitOfWork.CompleteAsync();

            var divisionDto = _mapper.Map<DivisionDto>(division);

            return new AddDivisionResponse { Division = divisionDto };
        }

        public async Task<DivisionsByAreaResponse> GetDivisionsByArea(DivisionsByAreaRequest request)
        {
            var divisions = await _unitOfWork.Divisions.GetDivisionsByArea(request.AreaId, request.Page, request.ItemsPerPage);
            
            List<DivisionDto> divisionDtos = new List<DivisionDto>();

            foreach (Division division in divisions)
            {
                var divisionDto = _mapper.Map<DivisionDto>(division);

                divisionDto.CountDepartments = await _unitOfWork.Departments.GetDepartmentsByDivisionCount(divisionDto.Id);

                divisionDtos.Add(divisionDto);
            }

            int divisionsByAreaCount = await _unitOfWork.Divisions.GetDivisionsByAreaSearchCount(request.AreaId);
            int pages = Convert.ToInt32(Math.Ceiling((double)divisionsByAreaCount / request.ItemsPerPage));

            DivisionsByAreaResponse response = new DivisionsByAreaResponse
            {
                AmountOfPages = pages,
                CurrentPage = divisionDtos.Count > 0 ? request.Page : 0,
                Divisions = divisionDtos
            };

            return response;
        } 
        public async Task<DivisionsByAreaSearchResponse> GetDivisionsByAreaAndSearch(DivisionsByAreaSearchRequest request)
        {
            var divisions = await _unitOfWork.Divisions.GetDivisionsByAreaSearch(request.AreaId, request.Filter, request.Page, request.ItemsPerPage);
            
            List<DivisionDto> divisionDtos = new List<DivisionDto>();

            foreach (Division division in divisions)
            {
                var divisionDto = _mapper.Map<DivisionDto>(division);

                divisionDto.CountDepartments = await _unitOfWork.Departments.GetDepartmentsByDivisionCount(divisionDto.Id);

                divisionDtos.Add(divisionDto);
            }

            int divisionsByAreaAndSearchCount = await _unitOfWork.Divisions.GetDivisionsByAreaSearchCount(request.AreaId);
            int pages = Convert.ToInt32(Math.Ceiling((double)divisionsByAreaAndSearchCount / request.ItemsPerPage));

            DivisionsByAreaSearchResponse response = new DivisionsByAreaSearchResponse
            {
                AmountOfPages = pages,
                CurrentPage = divisionDtos.Count > 0 ? request.Page : 0,
                Divisions = divisionDtos
            };

            return response;
        }

        public async Task<DivisionDto> GetById(int id)
        {
            var division = await _unitOfWork.Divisions.GetById(id);

            var divisionDto = _mapper.Map<DivisionDto>(division);

            divisionDto.CountDepartments = await _unitOfWork.Departments.GetDepartmentsByDivisionCount(divisionDto.Id);

            return divisionDto;
        }

        public async Task<bool> Removed(int id)
        {
            var isRemoved = await _unitOfWork.Divisions.Removed(id);
            await _unitOfWork.CompleteAsync();

            return isRemoved;
        }

        public async Task<EditDivisionResponse> Update(EditDivisionRequest request)
        {
            var division = _mapper.Map<Division>(request.Division);

            var divisionUpdated = await _unitOfWork.Divisions.Update(division);
            var divisionUpdatedDto = _mapper.Map<DivisionDto>(divisionUpdated);
            await _unitOfWork.CompleteAsync();

            return new EditDivisionResponse { Division = divisionUpdatedDto };
        }
    }
}
