using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace weatherxamarin.WeatherApi
{
    public class DarkSkyApi: IWeatherApi
    {
        public static string darkSkyBaseAddress = "https://api.darksky.net/forecast";

        private HttpClient httpClient;


        public DarkSkyApi() {
            httpClient = new HttpClient();
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

            Console.WriteLine($"converted object: {result.latitude}");

            return null;
        }
    }
}
