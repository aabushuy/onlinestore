using Store.Domen.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Domen.Interfaces.Services
{
	public interface ICatalogService
	{
		Task<IEnumerable<CatalogItem>> GetAsync(Expression<Func<CatalogItem, bool>> creteria = null);
	}
}
