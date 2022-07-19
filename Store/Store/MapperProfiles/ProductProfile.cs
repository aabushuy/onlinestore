using AutoMapper;
using Store.Domen.Entity;
using Store.Models;

namespace Store.MapperProfiles
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, ProductDetailsModel>()
				.ForMember(src => src.Title, opt => opt.MapFrom(src => src.Name))
				.ReverseMap();
		}
	}
}
