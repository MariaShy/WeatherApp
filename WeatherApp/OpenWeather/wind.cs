using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.OpenWeather
{
    class wind
    {
        private double _speed;
        public double speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value * 3.6;
            }
        }

        private double _deg;
        public double deg
        {
            get
            {
                return _deg;
            }
            set
            {
                _deg = value;                
            }
        }

        public double gust;

        public string direction(double deg)
        {
            string strDeg = "";
            if (deg < 20 || deg >= 340)
                strDeg = "N";
            else if (deg >= 20 && deg < 70)
                strDeg = "NE";
            else if (deg >= 70 && deg < 110)
                strDeg = "E";
            else if (deg >= 110 && deg < 160)
                strDeg = "SE";
            else if (deg >= 160 && deg < 200)
                strDeg = "S";
            else if (deg >= 200 && deg < 250)
                strDeg = "SW";
            else if (deg >= 250 && deg < 290)
                strDeg = "W";
            else if (deg >= 290 && deg < 340)
                strDeg = "NW";
            return strDeg;
        }
    }
}
