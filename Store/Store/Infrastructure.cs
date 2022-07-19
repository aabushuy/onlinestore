using Microsoft.Extensions.DependencyInjection;
using Store.Builders;
using Store.DataAccess.Repositories;
using Store.Domen.Interfaces.Repositories;
using Store.Domen.Interfaces.Services;
using Store.Interfaces;
using Store.MapperProfiles;
using Store.Services;

namespace Store
{
	public static class Infrastructure
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddRepositories();
			services.AddServices();
			services.AddMappers();
			services.AddBuilders();

			return services;
		}

		private static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			//services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
			services.AddScoped(typeof(ICatalogItemRepository), typeof(CatalogItemRepository));
			services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));

			return services;
		}

		private static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ICatalogService, CatalogService>();
			services.AddScoped<IProductService, ProductService>();

			return services;
		}

		private static IServiceCollection AddBuilders(this IServiceCollection services)
		{
			services.AddSingleton(typeof(ICatalogModelBuilder), typeof(CatalogModelBuilder));
			services.AddSingleton(typeof(IProductModelBuilder), typeof(ProductModelBuilder));

			return services;
		}

		private static IServiceCollection AddMappers(this IServiceCollection services)
		{
			services.AddAutoMapper(
				typeof(CatalogItemProfile),
				typeof(ProductProfile));

			return services;
		}
	}
}
