using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Support.Requests.UserControl;
using Util.Support.Responses.UserControl;

namespace Service.Service.ServiceImpl
{
    public class UserControlService : IUserControlService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserControlService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AddUserControlResponse> Add(AddUserControlRequest request)
        {
            var userControl = _mapper.Map<UserControl>(request.UserControl);

            userControl = await _unitOfWork.UserControls.Add(userControl);

            await _unitOfWork.CompleteAsync();

            var userControlDto = _mapper.Map<UserControlDto>(userControl);

            var response = new AddUserControlResponse
            {
                UserControl = userControlDto
            };

            return response;
        }

        public async Task<AddRangeUserControlResponse> AddRange(AddRangeUserControlRequest request)
        {
            List<UserControl> userControls = new List<UserControl>();

            foreach (UserControlDto userControlDto in request.UserControls)
            {
                var userControl = _mapper.Map<UserControl>(userControlDto);

                userControls.Add(userControl);
            }

            userControls = (List<UserControl>) await _unitOfWork.UserControls.AddRange(userControls);

            await _unitOfWork.CompleteAsync();

            var userControlsDto = new List<UserControlDto>();

            foreach (UserControl userControl in userControls)
            {
                var userControlDto = _mapper.Map<UserControlDto>(userControl);

                userControlsDto.Add(userControlDto);
            }

            var response = new AddRangeUserControlResponse
            {
                UserControls = userControlsDto
            };

            return response;
        }

        public async Task<EditUserControlResponse> Remove(EditUserControlRequest request)
        {
            var userControl = _mapper.Map<UserControl>(request.UserControl);

            userControl.DeallocatedDate = DateTime.Now;

            var userControlUpdated = await _unitOfWork.UserControls.Update(userControl);

            await _unitOfWork.CompleteAsync();

            var userControlDto = _mapper.Map<UserControlDto>(userControlUpdated);

            var response = new EditUserControlResponse
            {
                UserControl = userControlDto
            };

            return response;
        }

        public async Task<EditRangeUserControlResponse> RemoveRange(EditRangeUserControlRequest request)
        {
            List<UserControl> userControls = new List<UserControl>();

            foreach (UserControlDto usercontroldto in request.UserControls)
            {
                var userControl = _mapper.Map<UserControl>(usercontroldto);

                userControl.DeallocatedDate = DateTime.Now;

                userControls.Add(userControl);
            }

            var userControlsRemoved = await _unitOfWork.UserControls.UpdateRange(userControls);

            List<UserControlDto> userControlsDto = new List<UserControlDto>();

            foreach (UserControl usercontrol in userControlsRemoved)
            {
                var userControlDto = _mapper.Map<UserControlDto>(usercontrol);

                userControlsDto.Add(userControlDto);
            }

            var response = new EditRangeUserControlResponse
            {
                UserControls = userControlsDto
            };

            return response;
        }
    }
}
