using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.AutomationLevelDtos;
using Util.Support.Responses.MAutomationLevel;

namespace Service.Service.ServiceImpl
{
    public class MAutomationLevelService : IMAutomationLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MAutomationLevelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetAutomationLevelsResponse> GetAll()
        {
            var automationLevels = await _unitOfWork.AutomationLevels.GetAll();

            var automationLevelDtos = new List<MAutomationLevelReadDto>();

            foreach(MAutomationLevel automationLevel in automationLevels)
            {
                var automationLevelDto = _mapper.Map<MAutomationLevelReadDto>(automationLevel);
                automationLevelDtos.Add(automationLevelDto);
            }

            var response = new GetAutomationLevelsResponse
            {
                AutomationLevels = automationLevelDtos
            };

            return response;

        }
    }
}
