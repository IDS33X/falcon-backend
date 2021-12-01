using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Service.Service;
using Util.Dtos.AreaDtos;
using Util.Mappings;
using Util.Support.Requests.Area;
using Util.Support.Responses.Area;
using Domain.Models;

namespace Testing.AreaTests
{
    public class AreaServiceStub : IAreaService
    {

        private static List<Area> areas = new List<Area>();
        private static int areasCount = 0;

        private readonly IMapper _mapper;

        public AreaServiceStub()
        {
            _mapper = new Mapper(AutoMapperConfiguration.GetConfig());
            areas.Clear();
        }

        public async Task<AddAreaResponse> Add(AddAreaRequest request)
        {
            areasCount++;
            var area = _mapper.Map<Area>(request.Area);
            area.Id = areasCount;

            await Task.Run(() => areas.Add(area));

            var areaDto = _mapper.Map<AreaReadDto>(area);

            return new AddAreaResponse { Area = areaDto };

        }

        public async Task<GetAreasResponse> GetAreas(GetAreasRequest request)
        {
            var areasDto = new List<AreaReadDto>();

            foreach(var area in areas)
            {
                var areaDto = _mapper.Map<AreaReadDto>(area);
                await Task.Run(() => areasDto.Add(areaDto));
            }

            return new GetAreasResponse { Areas = areasDto };
        }

        public async Task<GetAreasSearchResponse> GetAreasBySearch(GetAreasSearchRequest request)
        {
            var areasDto = new List<AreaReadDto>();

            foreach(var area in areas.ToList())
            {
                if (area.Title.Contains(request.Filter))
                {
                    var areaDto = _mapper.Map<AreaReadDto>(area);
                    await Task.Run(() => areasDto.Add(areaDto));
                }
            }

            return new GetAreasSearchResponse() { Areas = areasDto };
        }

        public async Task<AreaReadDto> GetById(int id)
        {
            var area = await Task.Run(() => areas.Where(a => a.Id == id).FirstOrDefault());

            var areaDto = _mapper.Map<AreaReadDto>(area);

            return areaDto;
        }

        public async Task<bool> Removed(int id)
        {
            var area = await Task.Run(() => areas.Where(a => a.Id == id).FirstOrDefault());

            areas.Remove(area);

            return true;
        }

        public Task<EditAreaResponse> Update(EditAreaRequest request)
        {
            var area = _mapper.Map<Area>(request.Area);

            var update = areas.Where(a => a.Id == request.Area.Id).FirstOrDefault();

            update = area;

            var updatedArea = _mapper.Map<AreaReadDto>(update);

            return Task.FromResult(new EditAreaResponse() { Area = updatedArea });
            
        }

        //Static Methods
        public static void clearDatabase()
        {
            areas.Clear();
            areasCount = 0;
        }

        public static void AddRange(List<Domain.Models.Area> fakesAreas)
        {
            areas.AddRange(fakesAreas);
        }
    }
}
