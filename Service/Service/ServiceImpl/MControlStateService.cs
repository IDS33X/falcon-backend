using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.ControlStateDtos;
using Util.Support.Responses.MControlState;

namespace Service.Service.ServiceImpl
{
    public class MControlStateService : IMControlStateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MControlStateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetControlStatesResponse> GetAll()
        {
            var controlStates = await _unitOfWork.ControlStates.GetAll();

            var controlStateDtos = new List<MControlStateReadDto>();

            foreach(MControlState controlState in controlStates)
            {
                var controlStateDto = _mapper.Map<MControlStateReadDto>(controlState);
                controlStateDtos.Add(controlStateDto);
            }

            var response = new GetControlStatesResponse
            {
                ControlStates = controlStateDtos
            };

            return response;
        }
    }
}
