using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.OpenWeather
{
    class OpenWeather
    {
        public coord coord;

        public weather[] weather;

        [JsonProperty("base")]
        public string Base;

        public main main;

        public double visibility;

        public wind wind;

        public rain rain;

        public clouds clouds;

        public double dt;

        public sys sys;

        public double timezone;

        public int id;

        public string name;

        public double cod;

    }
}
