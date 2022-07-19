using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Domen.Interfaces.Services;
using Store.Interfaces;
using Store.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public partial class ProductController : ControllerBase
	{
		private readonly IProductModelBuilder _productModelBuilder;
		private readonly ICatalogModelBuilder _catalogModelBuilder;
		private readonly ICatalogService _catalogService;
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(
			IProductModelBuilder productModelBuilder,
			ICatalogModelBuilder catalogModelBuilder,
			ICatalogService catalogService,
			IProductService productService,
			IMapper mapper)
		{
			_productModelBuilder = productModelBuilder;
			_catalogModelBuilder = catalogModelBuilder;
			_catalogService = catalogService;
			_productService = productService;
			_mapper = mapper;
		}

		// GET: ProductController
		public async Task<ActionResult> Index()
		{
			_catalogModelBuilder.Init(ControllerName);

			var products = (await _productService.GetAsync())
					.Select(p => _mapper.Map<ProductDetailsModel>(p));

			_catalogModelBuilder.SetProducts(products);
			
			return View("~/Views/Catalog/Index.cshtml", _catalogModelBuilder.Build());
		}

		// GET: ProductController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var product = (await _productService.GetAsync(p => p.Id == id)).FirstOrDefault();
			if (product == null)
			{
				return NotFound(id);
			}

			var productDetails = _mapper.Map<ProductDetailsModel>(product);
			_productModelBuilder.Init(productDetails.Title);

			_productModelBuilder.SetProductDetails(productDetails);

			var category = (await _catalogService.GetAsync(c => c.Id == product.CategoryId)).FirstOrDefault();
			_productModelBuilder.SetCatalogItem(_mapper.Map<CatalogItemModel>(category));

			var products = (await _productService.GetAsync(p => p.CategoryId == productDetails.CategoryId))
				.Select(p => _mapper.Map<ProductDetailsModel>(p));

			_productModelBuilder.SetProducts(products);

			return View(_productModelBuilder.Build());
		}
	}
}
