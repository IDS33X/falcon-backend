using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Models;
using Service.Service;
using Util.Dtos.DivisionDtos;
using Util.Mappings;
using Util.Support.Requests.Division;
using Util.Support.Responses.Division;

namespace Testing.DivisionTests
{
    public class DivisionServiceStub : IDivisionService
    {
        private static List<Division> divisions = new List<Division>();
        private static int divisionsCount = 0;

        private readonly IMapper _mapper;

        public DivisionServiceStub()
        {
            _mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            divisions.Clear();
        }

        public Task<AddDivisionResponse> Add(AddDivisionRequest request)
        {
            divisionsCount++;
            var division = _mapper.Map<Division>(request.Division);
            division.Id = divisionsCount;

            divisions.Add(division);

            var divisionDto = _mapper.Map<DivisionReadDto>(division);

            return Task.FromResult(new AddDivisionResponse() { Division = divisionDto });
        }

        public Task<DivisionReadDto> GetById(int id)
        {
            var division = divisions.Where(d => d.Id == id).FirstOrDefault();

            var divisionDto = _mapper.Map<DivisionReadDto>(division);

            return Task.FromResult(divisionDto);
        }

        public Task<DivisionsByAreaResponse> GetDivisionsByArea(DivisionsByAreaRequest request)
        {
            var divisionsDto = new List<DivisionReadDto>();

            foreach(var div in divisions)
            {
                if(div.AreaId == request.AreaId)
                {
                    var divisionDto = _mapper.Map<DivisionReadDto>(div);
                    divisionsDto.Add(divisionDto);
                }
            }

            return Task.FromResult(new DivisionsByAreaResponse() { Divisions = divisionsDto });
        }

        public Task<DivisionsByAreaSearchResponse> GetDivisionsByAreaAndSearch(DivisionsByAreaSearchRequest request)
        {
            var divisionsDto = new List<DivisionReadDto>();

            foreach (var div in divisions.ToList())
            {
                if (div.AreaId == request.AreaId && div.Title.Contains(request.Filter))
                {
                    var divisionDto = _mapper.Map<DivisionReadDto>(div);
                    divisionsDto.Add(divisionDto);
                }
            }

            return Task.FromResult(new DivisionsByAreaSearchResponse() { Divisions = divisionsDto });
        }

        public Task<bool> Removed(int id)
        {
            var div = divisions.Where(d => d.Id == id).FirstOrDefault();
            
            if(div != null)
            {
                divisions.Remove(div);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<EditDivisionResponse> Update(EditDivisionRequest request)
        {
            var div = _mapper.Map<Division>(request.Division);

            var update = divisions.Where(d => d.Id == request.Division.Id).FirstOrDefault();

            update = div;

            var updatedDiv = _mapper.Map<DivisionReadDto>(update);

            return Task.FromResult(new EditDivisionResponse() { Division=updatedDiv});
        }

        //Static Methods
        public static void clearDatabase()
        {
            divisions.Clear();
            divisionsCount = 0;
        }

        public static void AddRange(List<Division> fakesAreas)
        {
            divisions.AddRange(fakesAreas);
        }
    }
}
