using Store.Domen.Entity;
using Store.Domen.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Repositories
{
	public class CatalogItemRepository : ICatalogItemRepository
	{
		public async Task<IEnumerable<CatalogItem>> GetAllAsync()
		{
			return new List<CatalogItem>()
			{
				new CatalogItem(){ Id = 1, Name ="Category #1", Description = "Cat description test 1"},
				new CatalogItem(){ Id = 2, Name ="Category #2", Description = "Cat description test 2 looong description"},
				new CatalogItem(){ Id = 3, Name ="Category #3", Description = "Cat description test 3"},
				new CatalogItem(){ Id = 4, Name ="Category #4", Description = "Cat description test 4"},
				new CatalogItem(){ Id = 5, Name ="Category #5", Description = "Cat description test 5"},

				new CatalogItem(){ Id = 5, Name ="Category inner #6", Description = "Cat description test 6", ParentId = 1},
				new CatalogItem(){ Id = 6, Name ="Category inner #7", Description = "Cat description test 7", ParentId = 1},
			};
		}

		public async Task<IEnumerable<CatalogItem>> GetAsync(Expression<Func<CatalogItem, bool>> selector)
		{
			return (await GetAllAsync()).Where(selector.Compile());
		}

		public async Task AddAsync(CatalogItem item)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateAsync(CatalogItem item)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteAsync(CatalogItem item)
		{
			throw new NotImplementedException();
		}
	}
}
