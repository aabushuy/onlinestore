using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Domen.Interfaces.Repositories
{
	public interface IRepositoryBase<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> selector);

		Task AddAsync(T item);

		Task UpdateAsync(T item);

		Task DeleteAsync(T item);
	}
}