using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public class WeatherAPI
    {
        private HttpClient client;

        public WeatherAPI()
        {
            this.client = new HttpClient();
        }

        public async Task<WeatherApiResponse> GetRealTimeWeather(string city)
        {
            string query = String.Format(Constant.baseUrl + Constant.endPoint + Constant.parameters, city);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(query),
                Headers =
                {
                    { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
                    { "X-RapidAPI-Key", Constant.apiKey },
                },
            };

            WeatherApiResponse weatherResponse = null;

            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    weatherResponse = JsonConvert.DeserializeObject<WeatherApiResponse>(content);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return weatherResponse;
        }
    }
}