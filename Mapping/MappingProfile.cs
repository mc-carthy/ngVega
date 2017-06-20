using AutoMapper;
using ngVega.Controllers.Resources;
using ngVega.Models;

namespace ngVega.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ensure the property names match in order for AutoMapper to work correctly
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
        }
    }
}