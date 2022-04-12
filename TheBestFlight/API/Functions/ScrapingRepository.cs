using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Functions
{
    public class ScrapingRepository : IScrapingRepository
    {
        public async Task<List<string>> ExtractCheapestFlights(string departure)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com/v1/prices/cheap?origin={departure}&page=None&currency=EUR&destination=-"),
				Headers =
				{
					{ "X-Access-Token", "f5df6fdc01b72e0264151f1f0915cd87" },
					{ "X-RapidAPI-Host", "travelpayouts-travelpayouts-flight-data-v1.p.rapidapi.com" },
					{ "X-RapidAPI-Key", "9ac54eedcemsh016f73ee6669031p11a70bjsn974be6947107" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				List<List<CheapestFlights>> aaaa = JsonConvert.DeserializeObject<List<List<CheapestFlights>>>(body);
			}
			return null;
		}
    }
}
