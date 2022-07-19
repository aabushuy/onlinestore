using Store.Interfaces;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Builders
{
	internal class CatalogModelBuilder : ICatalogModelBuilder
	{
		private CatalogModel _catalogModel;

		public void Init(string title)
		{
			_catalogModel = new CatalogModel()
			{
				Title = title
			};
		}

		public void SetCategories(IEnumerable<CatalogItemModel> catalogItemModels)
		{
			_catalogModel.Categories = catalogItemModels.ToList();
		}

		public void SetProducts(IEnumerable<ProductDetailsModel> productModels)
		{
			_catalogModel.Products = productModels.ToList();
		}

		public void SetProductFilter(ProductFilterModel productFilterModel)
		{
			_catalogModel.ProductFilter = productFilterModel;
		}

		public CatalogModel Build()
		{
			_catalogModel.Categories ??= new List<CatalogItemModel>();
			_catalogModel.Products ??= new List<ProductDetailsModel>();
			_catalogModel.ProductFilter ??= new ProductFilterModel();

			return _catalogModel;
		}
	}
}
