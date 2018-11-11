using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WebApplication1;

namespace UnitTestProject1
{
	public class UnitTest1
	{
		public TestServer Server { get; set; }
		public HttpClient Client { get; set; }

		public static IConfiguration InitConfiguration()
		{
			var config = new ConfigurationBuilder()
				.AddJsonFile("appsettings.json")
				.Build();
			return config;
		}

		public UnitTest1()
		{
			Server = new TestServer(new WebHostBuilder()
				.UseConfiguration(InitConfiguration())
				.UseStartup<Startup>());
			Client = Server.CreateClient();
		}

		[Test]
		public async Task TestMethod1()
		{
			var response = await Client.GetAsync("/api/values");
			response.EnsureSuccessStatusCode();
			var value = await response.Content.ReadAsStringAsync();
			Assert.AreEqual(value, "My Value 123");
		}
	}
}
