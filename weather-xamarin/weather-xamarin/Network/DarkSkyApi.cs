using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace weatherxamarin.WeatherApi
{
    public class DarkSkyApi: IWeatherApi
    {
        public static string darkSkyBaseAddress = "https://api.darksky.net/forecast/";


        public DarkSkyApi() {
            var httpClient = new HttpClient();
        }

        public async Task GetCurrentForecast(double latitude, double longitude) {
            try {
                var uriString = "{darkSkyBaseAddress}/{ApiKeys.DarkSkyApi}/{latitude},{longitude}";
                var request = new HttpWebRequest(new Uri(uriString));
                request.Method = "GET";


            }
        }
    }
}
