using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domen.Interfaces.Services;
using Store.Interfaces;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
	public partial class CatalogController : ControllerBase
	{
		private readonly ICatalogModelBuilder _catalogModelBuilder;
		private readonly ICatalogService _catalogService;
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public CatalogController(
			ICatalogModelBuilder catalogModelBuilder,
			ICatalogService catalogService,
			IProductService productService,
			IMapper mapper)
		{
			_catalogModelBuilder = catalogModelBuilder;
			_catalogService = catalogService;
			_productService = productService;
			_mapper = mapper;
		}

		// GET: CatalogController
		public ActionResult Index()
		{
			return RedirectToAction(nameof(Details), new { id = 0});
		}

		// GET: CatalogController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var currentCategory = (await _catalogService.GetAsync(c => c.Id == id)).FirstOrDefault();
			var pageTitle = currentCategory != null ? currentCategory.Name : ControllerName;

			_catalogModelBuilder.Init(pageTitle);

			var categories = (await _catalogService.GetAsync(c => c.ParentId == id))
				.Select(c => _mapper.Map<CatalogItemModel>(c));

			_catalogModelBuilder.SetCategories(categories);

			var products = (await _productService.GetAsync(p => p.CategoryId == id))
				.Select(p => _mapper.Map<ProductDetailsModel>(p));
			
			_catalogModelBuilder.SetProducts(products);

			return View("Index", _catalogModelBuilder.Build());
		}
	}
}
