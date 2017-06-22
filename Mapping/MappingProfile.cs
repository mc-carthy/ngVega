using System.Collections.Generic;
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
                // This is required to prevent the mapping attempting to change the primary key which will throw an error
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                    // Remove unselected features
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));

                    foreach(var f in removedFeatures)
                    {
                        v.Features.Remove(f);
                    }

                    // Add new features
                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id));

                    foreach (var id in addedFeatures)
                    {
                        v.Features.Add(new VehicleFeature{ FeatureId = id });
                    }
                });
        }
    }
}