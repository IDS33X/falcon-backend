using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Service.Service;
using Util.Dtos.ControlDtos;
using Util.Mappings;
using Util.Support.Requests.Control;
using Util.Support.Responses.Control;

namespace Testing.ControlTests
{
    public class ControlServiceStub : IControlService
    {
        private static List<Control> controls = new List<Control>();

        private readonly IMapper _mapper;

        public ControlServiceStub()
        {
            _mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            controls.Clear();
        }

        public Task<AddControlResponse> Add(AddControlRequest request)
        {
            var control = _mapper.Map<Control>(request.Control);
            control.Id = Guid.NewGuid();

            controls.Add(control);

            var dto = _mapper.Map<ControlReadDto>(control);

            return Task.FromResult(new AddControlResponse() { Control = dto });
        }
        public Task<GetControlsByRiskResponse> GetControlsByRisk(GetControlsByRiskRequest request)
        {
            var dtos = new List<ControlReadDto>();

            foreach (var con in controls)
            {
                if (con.Risks != null && con.Risks.Any(rc => rc.RiskId == request.RiskId))
                {
                    var dto = _mapper.Map<ControlReadDto>(con);
                    dtos.Add(dto);
                }
            }

            return Task.FromResult(new GetControlsByRiskResponse() { Controls = dtos });
        }
        public Task<GetControlsByRiskCategoryResponse> GetControlsByRiskCategory(GetControlsByRiskCategoryRequest request)
        {
            var dtos = new List<ControlReadDto>();

            foreach (var con in controls)
            {
                if (con.RiskCategoryId == request.RiskCategoryId)
                {
                    var dto = _mapper.Map<ControlReadDto>(con);
                    dtos.Add(dto);
                }
            }

            return Task.FromResult(new GetControlsByRiskCategoryResponse() { Controls = dtos });
        }
        public Task<ControlByCodeResponse> GetByCode(ControlByCodeRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetControlsResponse> GetControls(GetControlsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetControlsByCodeSearchResponse> GetControlsByCodeSearch(GetControlsByCodeSearchRequest request)
        {
            throw new NotImplementedException();
        }





        public Task<GetControlsByUserResponse> GetControlsByUser(GetControlsByUserRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<EditControlResponse> Update(EditControlRequest request)
        {
            throw new NotImplementedException();
        }



        //Static Methods
        public static void clearDatabase()
        {
            controls.Clear();
            
        }

        public static void AddRange(List<Control> fakesControls)
        {
            controls.AddRange(fakesControls);
        }
    }
}

   
