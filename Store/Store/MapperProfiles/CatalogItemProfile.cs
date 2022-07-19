using AutoMapper;
using Store.Domen.Entity;
using Store.Models;

namespace Store.MapperProfiles
{
	public class CatalogItemProfile : Profile
	{
		public CatalogItemProfile()
		{
			CreateMap<CatalogItem, CatalogItemModel>()
				.ForMember(src => src.Title, opt => opt.MapFrom(src => src.Name))
				.ReverseMap();
		}
	}
}
