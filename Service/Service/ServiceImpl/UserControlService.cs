using AutoMapper;
using Domain.Models;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;
using Util.Dtos.UserControl;
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

            foreach (AddUserControlDto userControlDto in request.UserControls)
            {
                var userControl = _mapper.Map<UserControl>(userControlDto);

                userControls.Add(userControl);
            }

            var (usersControlsAdded, usersControlsNotAdded) = await _unitOfWork.UserControls.AddRange(userControls);

            await _unitOfWork.CompleteAsync();

            var userControlsAddedDto = new List<UserControlDto>();

            foreach (UserControl userControl in usersControlsAdded)
            {
                var userControlDto = _mapper.Map<UserControlDto>(userControl);

                userControlsAddedDto.Add(userControlDto);
            }

            var usersControlsNotAddedDto = new List<UserControlErrorDto>();

            foreach (var (userControl, errorMessage) in usersControlsNotAdded)
            {
                var userControlErrorDto = _mapper.Map<UserControlErrorDto>(userControl);

                userControlErrorDto.ErrorMessage = errorMessage;

                usersControlsNotAddedDto.Add(userControlErrorDto);
            }

            var response = new AddRangeUserControlResponse
            {
                UserControlsAdded = userControlsAddedDto,
                UsersControlsNotAdded = usersControlsNotAddedDto
            };

            return response;
        }

        public async Task<RemoveUserControlResponse> Remove(RemoveUserControlRequest request)
        {
            var userControl = _mapper.Map<UserControl>(request.UserControl);

            var userControlUpdated = await _unitOfWork.UserControls.Update(userControl);

            await _unitOfWork.CompleteAsync();

            var userControlDto = _mapper.Map<UserControlDto>(userControlUpdated);

            var response = new RemoveUserControlResponse
            {
                UserControl = userControlDto
            };

            return response;
        }

        public async Task<RemoveRangeUserControlResponse> RemoveRange(RemoveRangeUserControlRequest request)
        {
            List<UserControl> userControls = new List<UserControl>();

            foreach (RemoveUserControlDto usercontroldto in request.UserControls)
            {
                var userControl = _mapper.Map<UserControl>(usercontroldto);

                userControl.DeallocatedDate = DateTime.Now;

                userControls.Add(userControl);
            }

            var (userControlsRemoved, userControlsNotRemoved) = await _unitOfWork.UserControls.UpdateRange(userControls);

            await _unitOfWork.CompleteAsync();

            List<UserControlDto> userControlsDto = new List<UserControlDto>();

            foreach (UserControl usercontrol in userControlsRemoved)
            {
                var userControlDto = _mapper.Map<UserControlDto>(usercontrol);

                userControlsDto.Add(userControlDto);
            }

            List<UserControlErrorDto> userControlsNotRemovedDto = new List<UserControlErrorDto>();

            foreach (var (userControl, errorMessage) in userControlsNotRemoved)
            {
                var userControlErrorDto = _mapper.Map<UserControlErrorDto>(userControl);
                userControlErrorDto.ErrorMessage = errorMessage;

                userControlsNotRemovedDto.Add(userControlErrorDto);
            }

            var response = new RemoveRangeUserControlResponse
            {
                UserControlsRemoved = userControlsDto,
                UserControlsNotRemoved = userControlsNotRemovedDto
            };

            return response;
        }
    }
}
