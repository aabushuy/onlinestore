using System.Collections.Generic;

namespace Store.Models
{
	public class CatalogModel
	{
		public string Title { get; set; }

		public List<CatalogItemModel> Categories { get; set; }

		public List<ProductDetailsModel> Products { get; set; }

		public ProductFilterModel ProductFilter { get; set; }
	}
}
