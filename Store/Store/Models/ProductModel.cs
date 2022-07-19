using System.Collections.Generic;

namespace Store.Models
{
	public class ProductModel
	{
		public string Title { get; set; }

		public ProductDetailsModel ProductDetails { get; set; }

		public CatalogItemModel CatalogItem { get; set; }

		public List<ProductDetailsModel> Products { get; set; }
	}
}
