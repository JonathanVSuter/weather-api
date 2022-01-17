namespace WeatherAPI.Core.Services.OpenWeather.GetCurrentWeather.Business
{
    public class Weather
    {        
        public Weather(int id,string main,string description,string icon)
        {
            this.Id = id;
            this.Main = main;
            this.Description = description;
            this.Icon = icon;
        }

        public int Id { get; }
        public string Main { get; }
        public string Description { get; }
        public string Icon { get; }
    }


}
