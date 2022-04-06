using System;
using Xamarin.Forms;

namespace WeatherAPI
{
    public partial class MainPage : ContentPage
    {
        private WeatherAPI weatherAPI;

        public MainPage()

        {
            InitializeComponent();

            weatherAPI = new WeatherAPI();
        }

        private async void btnGetWeather_Clicked(object sender, EventArgs e)
        {
            var city = edtCity.Text;
            WeatherApiResponse weatherResponse = await weatherAPI.GetRealTimeWeather(city);
            if (weatherResponse != null)
            {
                weatherImg.Source = "https:" + weatherResponse.Current.Condition.Image;
                lblTempC.Text = weatherResponse.Current.TempC.ToString();
                lblCondition.Text = weatherResponse.Current.Condition.Text;
                lblLocation.Text = weatherResponse.Location.City + ", " + weatherResponse.Location.Province + ", " + weatherResponse.Location.Country;
                lblCoordinates.Text = "Latitude: " + weatherResponse.Location.Latitude + " , " + "Longitude: " + weatherResponse.Location.Longitude;
                lblHumidity.Text = weatherResponse.Current.Humidity.ToString() + " %";
                lblFeelsLike.Text = weatherResponse.Current.FeelsLikeC.ToString() + " °C";
                lblTempF.Text = weatherResponse.Current.TempF.ToString() + " °f";
                lblVisibility.Text = weatherResponse.Current.Visibility.ToString() + " km";
            }
            else
            {
                _ = DisplayAlert("Alert", "City cannot be Empty", "Ok");
            }
        }
    }
}