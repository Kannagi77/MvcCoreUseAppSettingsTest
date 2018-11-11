using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
	public class ValuesService : IValuesService
	{
		private readonly string value;

		public ValuesService(IConfiguration config)
			: this(config["MyValue"])
		{
		}

		public ValuesService(string value)
		{
			this.value = value;
		}
		public string GetValue()
		{
			return value;
		}
	}
}