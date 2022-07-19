using Store.Domen.Entity;
using Store.Domen.Interfaces.Repositories;
using Store.Domen.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>> creteria = null)
		{
			return creteria == null
				? await _productRepository.GetAllAsync()
				: await _productRepository.GetAsync(creteria);
		}
	}
}
