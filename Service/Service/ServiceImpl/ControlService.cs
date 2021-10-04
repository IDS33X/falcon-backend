using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.Control;
using Util.Support.Responses.Control;

namespace Service.Service.ServiceImpl
{
    public class ControlService : IControlService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ControlService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddControlResponse> Add(AddControlRequest request)
        {
            var control = _mapper.Map<Control>(request.Control);

            control = await _unitOfWork.Controls.Add(control);
            await _unitOfWork.CompleteAsync();

            var controlDto = _mapper.Map<ControlDto>(control);

            var response = new AddControlResponse
            {
                Control = controlDto
            };

            return response;
        }

        public async Task<ControlByCodeResponse> GetByCode(ControlByCodeRequest request)
        {
            var control = await _unitOfWork.Controls.GetControlByCode(request.Code);

            var controlDto = _mapper.Map<ControlDto>(control);

            var response = new ControlByCodeResponse
            {
                Control = controlDto
            };

            return response;
        }

        public async Task<GetControlsResponse> GetControls(GetControlsRequest request)
        {
            var controls = await _unitOfWork.Controls.GetControls(request.Page, request.ItemsPerPage);

            List<ControlDto> controlDtos = new List<ControlDto>();

            foreach(Control control in controls)
            {
                var controlDto = _mapper.Map<ControlDto>(control);

                controlDtos.Add(controlDto);
            }

            int controlsCount = await _unitOfWork.Controls.GetControlsCount();
            int pages = Convert.ToInt32(Math.Ceiling((double)controlsCount / request.ItemsPerPage));

            var response = new GetControlsResponse
            {
                AmountOfPages = pages,
                CurrentPage = controlDtos.Count > 0 ? request.Page : 0,
                Controls = controlDtos
            };

            return response;
        }

        public async Task<GetControlsByRiskResponse> GetControlsByRisk(GetControlsByRiskRequest request)
        {
            var controls = await _unitOfWork.Controls.GetControlsByRisk(request.RiskId, request.Page, request.ItemsPerPage);

            List<ControlDto> controlDtos = new List<ControlDto>();

            foreach (Control control in controls)
            {
                var controlDto = _mapper.Map<ControlDto>(control);

                controlDtos.Add(controlDto);
            }

            int controlsCount = await _unitOfWork.Controls.GetControlsCount();
            int pages = Convert.ToInt32(Math.Ceiling((double)controlsCount / request.ItemsPerPage));

            var response = new GetControlsByRiskResponse
            {
                AmountOfPages = pages,
                CurrentPage = controlDtos.Count > 0 ? request.Page : 0,
                Controls = controlDtos
            };

            return response;
        }

        public async Task<GetControlsByUserResponse> GetControlsByUser(GetControlsByUserRequest request)
        {
            var controls = await _unitOfWork.Controls.GetControlsByUser(request.UserId, request.Page, request.ItemsPerPage);

            List<ControlDto> controlDtos = new List<ControlDto>();

            foreach (Control control in controls)
            {
                var controlDto = _mapper.Map<ControlDto>(control);

                controlDtos.Add(controlDto);
            }

            int controlsCount = await _unitOfWork.Controls.GetControlsCount();
            int pages = Convert.ToInt32(Math.Ceiling((double)controlsCount / request.ItemsPerPage));

            var response = new GetControlsByUserResponse
            {
                AmountOfPages = pages,
                CurrentPage = controlDtos.Count > 0 ? request.Page : 0,
                Controls = controlDtos
            };

            return response;
        }

        public async Task<EditControlResponse> Update(EditControlRequest request)
        {
            var control = _mapper.Map<Control>(request.Control);

            var controlUpdated = await _unitOfWork.Controls.Update(control);
            var controlUpdatedDto = _mapper.Map<ControlDto>(controlUpdated);

            await _unitOfWork.CompleteAsync();

            var response = new EditControlResponse
            {
                Control = controlUpdatedDto
            };

            return response;
        }
    }
}
