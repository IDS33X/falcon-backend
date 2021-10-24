using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util.Dtos.RiskControl;
using Util.Support.Requests.RiskControl;
using Util.Support.Responses.RiskControl;

namespace Service.Service.ServiceImpl
{
    public class RiskControlService : IRiskControlService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskControlService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddRiskControlResponse> Add(AddRiskControlRequest request)
        {
            var riskControl = _mapper.Map<RiskControl>(request.RiskControl);

            riskControl = await _unitOfWork.RiskControls.Add(riskControl);

            await _unitOfWork.CompleteAsync();

            var riskControlDto = _mapper.Map<RiskControlDto>(riskControl);

            var response = new AddRiskControlResponse
            {
                RiskControl = riskControlDto
            };

            return response;
        }

        public async Task<AddRangeRiskControlResponse> AddRange(AddRangeRiskControlRequest request)
        {
            List<RiskControl> riskControls = new List<RiskControl>();

            foreach(AddRiskControlDto riskControlDto in request.RiskControls)
            {
                var riksControl = _mapper.Map<RiskControl>(riskControlDto);

                riskControls.Add(riksControl);
            }

            var (riskControlsAdded, riskControlsNotAdded) = await _unitOfWork.RiskControls.AddRange(riskControls);

            await _unitOfWork.CompleteAsync();

            var riskControlsAddedDto = new List<RiskControlDto>();

            foreach (RiskControl riskControl in riskControlsAdded)
            {
                var riksControlDto = _mapper.Map<RiskControlDto>(riskControl);

                riskControlsAddedDto.Add(riksControlDto);
            }

            var riskControlsNotAddedDto = new List<RiskControlErrorDto>();

            foreach (var item in riskControlsNotAdded)
            {
                var riskControlErrorDto = _mapper.Map<RiskControlErrorDto>(item.riskControl);
                riskControlErrorDto.ErrorMessage = item.errorMessage;

                riskControlsNotAddedDto.Add(riskControlErrorDto);
            }

            var response = new AddRangeRiskControlResponse
            {
                RiskControlsAdded = riskControlsAddedDto,
                RiskControlsNotAdded = riskControlsNotAddedDto
            };

            return response;
        }

        public async Task<EditRiskControlResponse> Remove(EditRiskControlRequest request)
        {
            var riskControl = _mapper.Map<RiskControl>(request.RiskControl);

            riskControl.DeallocatedDate = DateTime.Now;

            var riskControlUpdated = await _unitOfWork.RiskControls.Update(riskControl);

            await _unitOfWork.CompleteAsync();

            var riskControlDto = _mapper.Map<RiskControlDto>(riskControlUpdated);

            var response = new EditRiskControlResponse
            {
                RiskControl = riskControlDto
            };

            return response;

        }

        public async Task<EditRangeRiskControlResponse> RemoveRange(EditRangeRiskControlRequest request)
        {
            List<RiskControl> riskControls = new List<RiskControl>();

            foreach(RemoveRiskControlDto riskcontroldto in request.RiskControls)
            {
                var riskControl = _mapper.Map<RiskControl>(riskcontroldto);

                riskControl.DeallocatedDate = DateTime.Now;

                riskControls.Add(riskControl);
            }

            var (riskControlsRemoved, riskControlsNotRemoved) = await _unitOfWork.RiskControls.UpdateRange(riskControls);

            await _unitOfWork.CompleteAsync();

            List<RiskControlDto> riskControlsDto = new List<RiskControlDto>();

            foreach (RiskControl riskcontrol in riskControlsRemoved)
            {
                var riskControlDto = _mapper.Map<RiskControlDto>(riskcontrol);

                riskControlsDto.Add(riskControlDto);
            }

            List<RiskControlErrorDto> riskControlErrorsDto = new List<RiskControlErrorDto>();

            foreach (var (riskControl, errorMessage) in riskControlsNotRemoved)
            {
                var riskControlErrorDto = _mapper.Map<RiskControlErrorDto>(riskControl);
                riskControlErrorDto.ErrorMessage = errorMessage;

                riskControlErrorsDto.Add(riskControlErrorDto);
            }

            var response = new EditRangeRiskControlResponse
            {
                RiskControlsRemoved = riskControlsDto,
                RiskControlsNotRemoved = riskControlErrorsDto
            };

            return response;
        }
    }
}
