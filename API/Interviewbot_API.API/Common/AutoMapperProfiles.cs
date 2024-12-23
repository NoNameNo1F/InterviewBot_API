using AutoMapper;
using Interviewbot_API.BuildingBlocks.Application.Common.Files;

namespace Interviewbot_API.API.Common;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles() {
        CreateMap<IFormFile, FileData>()
            .ForMember(
                fd => fd.Content, 
                ff => ff.MapFrom((ff => ff.OpenReadStream())));
    }
}