using Store.Interfaces;
using Store.Models;
using System.Collections.Generic;
using System.Linq;

namespace Store.Builders
{
	public class ProductModelBuilder : IProductModelBuilder
	{
		private ProductModel _productModel;

		public void Init(string title)
		{
			_productModel = new ProductModel()
			{
				Title = title
			};
		}

		public void SetProductDetails(ProductDetailsModel productDetailsModel)
		{
			_productModel.ProductDetails = productDetailsModel;
		}

		public void SetCatalogItem(CatalogItemModel catalogItemModel)
		{
			_productModel.CatalogItem = catalogItemModel;
		}

		public void SetProducts(IEnumerable<ProductDetailsModel> productDetailsModels)
		{
			_productModel.Products = productDetailsModels.ToList();
		}

		public ProductModel Build()
		{
			_productModel.ProductDetails ??= new ProductDetailsModel();
			_productModel.Products ??= new List<ProductDetailsModel>();

			return _productModel;
		}
	}
}
