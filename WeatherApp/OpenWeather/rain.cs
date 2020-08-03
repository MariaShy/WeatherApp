using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WeatherApp.OpenWeather
{
    class rain
    {
        [JsonProperty("1h")]
        public double h1;
    }
}
