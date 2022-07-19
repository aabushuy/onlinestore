using Store.Domen.Entity;
using Store.Domen.Interfaces.Repositories;
using Store.Domen.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services
{
	public class CatalogService : ICatalogService
	{
		private readonly ICatalogItemRepository _catalogItemRepository;

		public CatalogService(ICatalogItemRepository catalogItemRepository)
		{
			_catalogItemRepository = catalogItemRepository;
		}

		public async Task<IEnumerable<CatalogItem>> GetAsync(Expression<Func<CatalogItem, bool>> creteria = null)
		{
			return creteria == null 
				? await _catalogItemRepository.GetAllAsync()
				: await _catalogItemRepository.GetAsync(creteria);
		}
	}
}
