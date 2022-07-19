using Store.Domen.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Domen.Interfaces.Services
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetAsync(Expression<Func<Product, bool>> creteria = null);
	}
}
