using Newtonsoft.Json;

namespace WeatherAPI
{
    public class WeatherApiResponse
    {
        [JsonProperty("location")]
        public WeatherApiResponseLocation Location { get; set; }

        [JsonProperty("current")]
        public WeatherApiResponseCurrent Current { get; set; }
    }

    public class WeatherApiResponseLocation
    {
        [JsonProperty("name")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Province { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }

    public class WeatherApiResponseCurrent
    {
        [JsonProperty("temp_c")]
        public double TempC { get; set; }

        [JsonProperty("temp_f")]
        public double TempF { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("feelslike_c")]
        public double FeelsLikeC { get; set; }

        [JsonProperty("vis_km")]
        public double Visibility { get; set; }

        [JsonProperty("condition")]
        public WeatherApiResponseCurrentCondition Condition { get; set; }
    }

    public class WeatherApiResponseCurrentCondition
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Image { get; set; }
    }
}