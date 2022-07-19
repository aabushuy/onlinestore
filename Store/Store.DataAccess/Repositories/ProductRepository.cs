using Store.Domen.Entity;
using Store.Domen.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories
{
	public class ProductRepository : IProductRepository
	{
		public async Task<IEnumerable<Product>> GetAllAsync()
		{
			return new List<Product>()
			{
				new Product(){ Id = 1, Name="Product #1", Description="Description for product #1", CategoryId =5},
				new Product(){ Id = 2, Name="Product #2", Description="Description for product #2", CategoryId =5},
				new Product(){ Id = 3, Name="Product #3", Description="Description for product #3", CategoryId =5},

				new Product(){ Id = 4, Name="Product #4", Description="Description for product #4", CategoryId =2},
				new Product(){ Id = 5, Name="Product #5", Description="Description for product #5", CategoryId =2},
				new Product(){ Id = 6, Name="Product #6", Description="Description for product #6", CategoryId =2},
				new Product(){ Id = 7, Name="Product #7", Description="Description for product #7", CategoryId =2},
				new Product(){ Id = 8, Name="Product #8", Description="Description for product #8", CategoryId =2},
			};
		}

		public async Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>> selector)
		{
			return (await GetAllAsync()).Where(selector.Compile());
		}

		public async Task AddAsync(Product item)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateAsync(Product item)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteAsync(Product item)
		{
			throw new NotImplementedException();
		}
	}
}
