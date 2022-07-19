using Store.Models;
using System.Collections.Generic;

namespace Store.Interfaces
{
	public interface ICatalogModelBuilder
	{
		void Init(string title);

		void SetCategories(IEnumerable<CatalogItemModel> catalogItemModels);

		void SetProducts(IEnumerable<ProductDetailsModel> productModels);

		void SetProductFilter(ProductFilterModel productFilterModel);

		CatalogModel Build();
	}
}
