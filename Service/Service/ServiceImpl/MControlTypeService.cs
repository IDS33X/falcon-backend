using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Responses.MControlType;

namespace Service.Service.ServiceImpl
{
    public class MControlTypeService : IMControlTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MControlTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetControlTypesResponse> GetAll()
        {
            var controlTypes = await _unitOfWork.ControlTypes.GetAll();

            var controlTypeDtos = new List<MControlTypeDto>();

            foreach (MControlType controlType in controlTypes)
            {
                var controlTypeDto = _mapper.Map<MControlTypeDto>(controlType);
                controlTypeDtos.Add(controlTypeDto);
            }

            var response = new GetControlTypesResponse
            {
                ControlTypes = controlTypeDtos
            };

            return response;
        }
    }
}
