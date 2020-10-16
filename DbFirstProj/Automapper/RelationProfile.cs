using AutoMapper;
using DbFirstProj.Entities;
using DbFirstProj.ViewModels;

namespace DbFirstProj.Automapper
{
    public class RelationProfile : Profile
    {
        public RelationProfile()
        {
            CreateMap<Relation, RelationViewModel>().ReverseMap();
            CreateMap<RelationAddress, RelationViewModel>().ReverseMap();
            CreateMap<Country, CountryReadViewModel>().ReverseMap();
            CreateMap<AddressType, AddressTypeReadViewModel>().ReverseMap();
        }
    }
}