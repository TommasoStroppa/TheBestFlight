﻿using API.Models;
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
        public async Task<List<CheapestDestination>> ExtractCheapestFlights(string departure)
        {
			List<CheapestDestination> eleDestinazioni = new List<CheapestDestination>(); 
			RootCheapestFlights root;
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
				root = JsonConvert.DeserializeObject<RootCheapestFlights>(body);
			}
			string data = root.data.ToString();

			Dictionary<string, object> responses = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);			
			foreach (var item in responses)
            {
				CheapestDestination dest = new CheapestDestination();
				List<CheapestFlight> eleVoli = new List<CheapestFlight>();
				dest.destination = item.Key;
				
				string json = JsonConvert.SerializeObject(item.Value);
				var responsesB = JsonConvert.DeserializeObject<Dictionary<int, object>>(json);
				foreach(var itemB in responsesB)
                {
					string JsonVolo = JsonConvert.SerializeObject(itemB.Value);
					CheapestFlight volo = JsonConvert.DeserializeObject<CheapestFlight>(JsonVolo);
					eleVoli.Add(volo);
                }
				dest.cheapestFlights = eleVoli;
				eleDestinazioni.Add(dest);
			}
			return eleDestinazioni;
		}
		public async Task<Airline> ExtractAirlineInfo(string iata)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://iata-and-icao-codes.p.rapidapi.com/airline?iata_code={iata}"),
				Headers =
				{
					{ "X-RapidAPI-Host", "iata-and-icao-codes.p.rapidapi.com" },
					{ "X-RapidAPI-Key", "9ac54eedcemsh016f73ee6669031p11a70bjsn974be6947107" },
				},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var result = JsonConvert.DeserializeObject<Airline>(body);
				return result;
			}
		}
	}
}
