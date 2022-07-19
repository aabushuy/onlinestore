using Store.Models;
using System.Collections.Generic;

namespace Store.Interfaces
{
	public interface IProductModelBuilder
	{
		void Init(string title);

		void SetProductDetails(ProductDetailsModel productDetailsModel);

		void SetProducts(IEnumerable<ProductDetailsModel> productDetailsModels);

		void SetCatalogItem(CatalogItemModel catalogItemModel);

		ProductModel Build();
	}
}
