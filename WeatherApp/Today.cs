using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using WeatherApp.OpenWeather;

namespace WeatherApp
{
    public partial class Today : Form
    {        
        public Today()
        {
            InitializeComponent();
            Program.cityName = textBox1.Text;
        }               

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Program.cityName = textBox1.Text;
                //for russian description paste "&lang=ru" before &APPID
                panel1.Text = "Weather in " + Program.cityName; //  не работает ????
                Program.cityName = textBox1.Text;
                string str = "http://api.openweathermap.org/data/2.5/weather?q=" + Program.cityName + "&APPID=1d0fd92330221c38bcc652af7481a5a1";

                WebRequest request = WebRequest.Create(str);
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";

                WebResponse responce = await request.GetResponseAsync();

                string answer = ""; //or String.Empty();

                using (Stream s = responce.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }

                responce.Close();

                richTextBox1.Text = answer;

                OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

                panel1.BackgroundImage = oW.weather[0].Icon;
                label1.Text = oW.weather[0].main;
                label2.Text = oW.weather[0].description;
                label3.Text = "Avg Temperature, Celsium: " + oW.main.temp.ToString("0.0");
                label9.Text = "Feels like, Celsium: " + oW.main.feels_like.ToString("0.0");
                label4.Text = "Humidity, %: " + oW.main.humidity.ToString();
                label5.Text = "Pressure, mm: " + ((int)oW.main.pressure).ToString();
                label6.Text = "Speed, km/h: " + ((int)oW.wind.speed).ToString();
                label7.Text = "Direction (from): " + oW.wind.direction(oW.wind.deg);
            }
            catch
            {
                MessageBox.Show("Loading failed...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forecust3day f2 = new Forecust3day();
            f2.Show();
        }

        private async void Today_Load(object sender, EventArgs e)
        {
            try
            {
                //Program.cityName = textBox1.Text;
                //for russian description paste "&lang=ru" before &APPID
                panel1.Text = "Weather in " + Program.cityName; //  не работает ????
                string str = "http://api.openweathermap.org/data/2.5/weather?q=" + Program.cityName + "&APPID=1d0fd92330221c38bcc652af7481a5a1";

                WebRequest request = WebRequest.Create(str);
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";

                WebResponse responce = await request.GetResponseAsync();

                string answer = ""; //or String.Empty();

                using (Stream s = responce.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }
                }

                responce.Close();

                richTextBox1.Text = answer;

                OpenWeather.OpenWeather oW = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);

                panel1.BackgroundImage = oW.weather[0].Icon;
                label1.Text = oW.weather[0].main;
                label2.Text = oW.weather[0].description;
                label3.Text = "Avg Temperature, Celsium: " + oW.main.temp.ToString("0.0");
                label9.Text = "Feels like, Celsium: " + oW.main.feels_like.ToString("0.0");
                label4.Text = "Humidity, %: " + oW.main.humidity.ToString();
                label5.Text = "Pressure, mm: " + ((int)oW.main.pressure).ToString();
                label6.Text = "Speed, km/h: " + ((int)oW.wind.speed).ToString();
                label7.Text = "Direction (from): " + oW.wind.direction(oW.wind.deg);
            }
            catch
            {
                MessageBox.Show("Loading failed...");
            }
        }
    }
}
