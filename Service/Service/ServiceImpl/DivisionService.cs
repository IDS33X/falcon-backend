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
    public class DivisionService : IDivisionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DivisionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DivisionDto> Add(DivisionDto divisionDto)
        {
            var division = _mapper.Map<Division>(divisionDto);

            division = await _unitOfWork.Divisions.Add(division);

            await _unitOfWork.CompleteAsync();

            divisionDto = _mapper.Map<DivisionDto>(division);

            return divisionDto;
        }

        public async Task<IEnumerable<DivisionDto>> GetAll()
        {
            var divisions = await _unitOfWork.Divisions.GetAll();

            List<DivisionDto> divisionDtos = new List<DivisionDto>();

            foreach (Division division in divisions)
            {
                var divisionDto = _mapper.Map<DivisionDto>(division);

                divisionDto.CountDepartments = await _unitOfWork.Divisions.GetDepartmentCount(divisionDto.DivisionId);

                divisionDtos.Add(divisionDto);
            }

            return divisionDtos;
        }

        public async Task<DivisionDto> GetById(int id)
        {
            var division = await _unitOfWork.Divisions.GetById(id);

            var divisionDto = _mapper.Map<DivisionDto>(division);

            divisionDto.CountDepartments = await _unitOfWork.Divisions.GetDepartmentCount(divisionDto.DivisionId);

            return divisionDto;
        }

        public async Task<bool> Removed(int id)
        {
            var isRemoved = await _unitOfWork.Divisions.Removed(id);
            await _unitOfWork.CompleteAsync();

            return isRemoved;
        }

        public async Task<bool> Update(DivisionDto divisionDto)
        {
            var division = _mapper.Map<Division>(divisionDto);

            var isUpdated = await _unitOfWork.Divisions.Update(division);
            await _unitOfWork.CompleteAsync();

            return isUpdated;
        }
    }
}
