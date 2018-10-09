using System;
using weatherxamarin.WeatherApi;

namespace weatherxamarin.Presenter
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
    }
}
