using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace weatherxamarin.WeatherApi
{
    public class DarkSkyApi
    {
        public static string darkSkyBaseAddress = "https://api.darksky.net/forecast";

        private static DarkSkyApi api;
        private HttpClient httpClient; 

        public DarkSkyApi() {
            httpClient = new HttpClient();
        }

        public static DarkSkyApi Instance {
            get {
                if (api == null) {
                    api = new DarkSkyApi();
                }

                return api;
            }
        }

        public async Task<CurrentForecast> GetCurrentForecast(double latitude, double longitude) {
            var serviceExcludeList = "minutely,hourly,daily,alerts,flags";
            var uriString = $"{darkSkyBaseAddress}/{ApiKeys.DarkSkyApi}/{latitude},{longitude}?exclude={serviceExcludeList}";
            Console.WriteLine(uriString);

            Task<String> forecastTask = httpClient.GetStringAsync(uriString);

            string responseString = await forecastTask;
            Console.WriteLine($"response: {responseString}");

            ForecastResult result =
                JsonConvert.DeserializeObject<ForecastResult>(responseString);

            Console.WriteLine($"converted object: {result.currently.summary}");

            return result.currently;
        }
    }
}
