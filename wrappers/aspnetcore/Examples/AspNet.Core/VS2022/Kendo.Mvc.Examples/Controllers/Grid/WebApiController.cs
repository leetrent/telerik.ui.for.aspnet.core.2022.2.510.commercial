using System.Linq;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kendo.Mvc.Examples.Controllers
{
	public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult WebApi()
		{
			return View();
		}
	}

	[Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductService service;

        public ProductController(
            IProductService productService)
		{
			service = productService;
		}

		// GET: api/values
		[HttpGet]
		public DataSourceResult Get([DataSourceRequest]DataSourceRequest request)
		{
			return service.Read().ToDataSourceResult(request);
		}

        // POST api/values
        [HttpPost]
        public IActionResult Post(ProductViewModel product)
        {
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
            }

			service.Create(product);

			return new ObjectResult(new DataSourceResult { Data = new[] { product }, Total = 1 });
		}

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProductViewModel product)
        {
			if (ModelState.IsValid && id == product.ProductID)
			{
				try
				{
					service.Update(product);
				}
				catch (DbUpdateConcurrencyException)
				{
					return new NotFoundResult();
				}

				return new StatusCodeResult(200);
            }
			else
			{
				return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage));
			}
		}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {	
			try
			{
				service.Destroy(new ProductViewModel { ProductID = id } );
			}
			catch (DbUpdateConcurrencyException)
			{
				return new NotFoundResult();
			}

			return new StatusCodeResult(200);
		}
    }
}
