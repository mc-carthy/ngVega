using System.Linq;
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

            // Domain to API Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource{
                    Name = v.ContactName,
                    Phone = v.ContactPhone,
                    Email = v.ContactEmail
                }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            // API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature{ FeatureId = id})));
        }
    }
}