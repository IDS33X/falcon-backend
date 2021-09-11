using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Area;
using Util.Support.Responses;
using Util.Support.Responses.Area;

namespace Service.Service.ServiceImpl
{
    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AreaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AddAreaResponse> Add(AddAreaRequest request)
        {
            var area = _mapper.Map<Area>(request.Area);

            area = await _unitOfWork.Areas.Add(area);
            await _unitOfWork.CompleteAsync();

            var areaDto = _mapper.Map<AreaDto>(area);

            AddAreaResponse response = new AddAreaResponse
            {
                Area = areaDto
            };

            return response;
        }

        public async Task<GetAreasResponse> GetAreas(GetAreasRequest request)
        {
            var areas = await _unitOfWork.Areas.GetAreas(request.Page, request.ItemsPerPage);

            List<AreaDto> areaDtos = new List<AreaDto>();

            foreach (Area area in areas)
            {
                var areaDto = _mapper.Map<AreaDto>(area);
                
                areaDto.CountDivisions = await _unitOfWork.Divisions.GetDivisionsByAreaCount(areaDto.Id);
                
                areaDtos.Add(areaDto);
            }

            int areasCount = await _unitOfWork.Areas.GetAreasCount();
            int pages = Convert.ToInt32(Math.Ceiling((double)areasCount / request.ItemsPerPage));

            GetAreasResponse response = new GetAreasResponse
            {
                AmountOfPages = pages,
                CurrentPage = areaDtos.Count > 0 ? request.Page : 0,
                Areas = areaDtos
            };

            return response;
        } 
        public async Task<GetAreasSearchResponse> GetAreasBySearch(GetAreasSearchRequest request)
        {
            var areas = await _unitOfWork.Areas.GetAreasSearch(request.Filter, request.Page, request.ItemsPerPage);

            List<AreaDto> areaDtos = new List<AreaDto>();

            foreach (Area area in areas)
            {
                var areaDto = _mapper.Map<AreaDto>(area);
                
                areaDto.CountDivisions = await _unitOfWork.Divisions.GetDivisionsByAreaCount(areaDto.Id);
                
                areaDtos.Add(areaDto);
            }

            int areasBySearchCount = await _unitOfWork.Areas.GetAreasSearchCount(request.Filter);
            int pages = Convert.ToInt32(Math.Ceiling((double)areasBySearchCount / request.ItemsPerPage));

            GetAreasSearchResponse response = new GetAreasSearchResponse
            {
                AmountOfPages = pages,
                CurrentPage = areaDtos.Count > 0 ? request.Page : 0,
                Areas = areaDtos
            };

            return response;
        }

        public async Task<AreaDto> GetById(int id)
        {
            var area = await _unitOfWork.Areas.GetById(id);

            var areaDto = _mapper.Map<AreaDto>(area);

            areaDto.CountDivisions = await _unitOfWork.Divisions.GetDivisionsByAreaCount(areaDto.Id);

            return areaDto;
        }

        public async Task<bool> Removed(int id)
        {
            var isRemoved = await _unitOfWork.Areas.Removed(id);
            await _unitOfWork.CompleteAsync();

            return isRemoved;
        }

        public async Task<EditAreaResponse> Update(EditAreaRequest request)
        {
            var area = _mapper.Map<Area>(request.Area);

            var areaUpdated = await _unitOfWork.Areas.Update(area);
            var areaUpdatedDto = _mapper.Map<AreaDto>(areaUpdated);
            await _unitOfWork.CompleteAsync();

            EditAreaResponse response = new EditAreaResponse
            {
                Area = areaUpdatedDto
            };

            return response;
        }
    }
}
