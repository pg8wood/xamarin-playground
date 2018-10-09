using System;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Features.CurrentWeather
{
    public interface ICurrentForecastView
    {
        void OnReceiveForecast(CurrentForecast forecast);
    }

    public class CurrentForecastPresenter
    {
        private ICurrentForecastView View;

        public CurrentForecastPresenter(ICurrentForecastView View)
        {
            this.View = View;
        }

        public void start() {
            var interactor = new CurrentForecastInteractor();
            CurrentForecast forecast = interactor.getCurrentForecast();

            // TODO call start from view and see if stuff works 
            Console.WriteLine($"{forecast.summary}");

        }
    }
}
