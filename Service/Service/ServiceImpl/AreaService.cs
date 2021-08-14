using AutoMapper;
using Domain.Models;
using Repository.Repository;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

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
        public async Task<AreaDto> Add(AreaDto areaDto)
        {
            var area = _mapper.Map<Area>(areaDto);

            area = await _unitOfWork.Areas.Add(area);
            await _unitOfWork.CompleteAsync();

            areaDto = _mapper.Map<AreaDto>(area);

            return areaDto;
        }

        public async Task<IEnumerable<AreaDto>> GetAll()
        {
            var areas = await _unitOfWork.Areas.GetAll();

            List<AreaDto> areaDtos = new List<AreaDto>();

            foreach (Area area in areas)
            {
                var areaDto = _mapper.Map<AreaDto>(area);
                
                areaDto.CountDivisions = await _unitOfWork.Areas.GetDivisionsCount(areaDto.AreaId);
                
                areaDtos.Add(areaDto);
            }

            return areaDtos;
        }

        public async Task<AreaDto> GetById(int id)
        {
            var area = await _unitOfWork.Areas.GetById(id);

            var areaDto = _mapper.Map<AreaDto>(area);

            areaDto.CountDivisions = await _unitOfWork.Areas.GetDivisionsCount(areaDto.AreaId);

            return areaDto;
        }

        public async Task<bool> Removed(int id)
        {
            var isRemoved = await _unitOfWork.Areas.Removed(id);
            await _unitOfWork.CompleteAsync();

            return isRemoved;
        }

        public async Task<bool> Update(AreaDto areaDto)
        {
            var area = _mapper.Map<Area>(areaDto);

            var isUpdated = await _unitOfWork.Areas.Update(area);
            await _unitOfWork.CompleteAsync();

            return isUpdated;
        }
    }
}
