using AutoMapper;
using DbFirstProj.Entities;
using DbFirstProj.ViewModels;

namespace DbFirstProj.Automapper
{
    public class RelationProfile : Profile
    {
        public RelationProfile()
        {
            CreateMap<Relation, RelationReadViewModel>()
                .ForMember(r => r.CountryName, opt => opt.MapFrom(b => b.RelationAddresses[0].Country.Name))
                .ForMember(r => r.City, opt => opt.MapFrom(b => b.RelationAddresses[0].City))
                .ForMember(r => r.PostalCode, opt => opt.MapFrom(b => b.RelationAddresses[0].PostalCode))
                .ForMember(r => r.Number, opt => opt.MapFrom(b => b.RelationAddresses[0].Number))
                .ForMember(r => r.Street, opt => opt.MapFrom(b => b.RelationAddresses[0].Street))
                .ForMember(r => r.RelationId, opt => opt.MapFrom(b => b.Id))
                .ForMember(r => r.RelationAddressId, opt => opt.MapFrom(b => b.RelationAddresses[0].Id));

            CreateMap<RelationReadViewModel, Relation>()
                .ForMember(r => r.Id, opt => opt.MapFrom(b => b.RelationId));

            CreateMap<Relation, RelationPostViewModel>();

            CreateMap<RelationAddress, RelationReadViewModel>();

            CreateMap<RelationReadViewModel, RelationAddress>()
                .ForMember(r => r.Id, opt => opt.MapFrom(b => b.RelationAddressId))
                .ForMember(r => r.CountryId, opt => opt.MapFrom(b => b.CountryId));

            CreateMap<Country, CountryReadViewModel>().ReverseMap();

        }
    }
}