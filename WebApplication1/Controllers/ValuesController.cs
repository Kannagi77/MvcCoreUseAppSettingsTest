using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly IValuesService valuesService;
		public ValuesController(IValuesService valuesService)
		{
			this.valuesService = valuesService;
		}

		public ActionResult<string> Get()
		{
			return valuesService.GetValue();
		}
	}
}
