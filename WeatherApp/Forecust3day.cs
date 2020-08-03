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


namespace WeatherApp
{
    public partial class Forecust3day : Form
    {
        public Forecust3day()
        {
            InitializeComponent();
        }

        private async void Forecust_Load(object sender, EventArgs e)
        {
            try
            {
                string str = "http://api.openweathermap.org/data/2.5/forecast?q=" + Program.cityName + "&APPID=1d0fd92330221c38bcc652af7481a5a1";

                WebRequest request = WebRequest.Create(str);
                request.Method = "POST";
                request.ContentType = "application/x-www-urlencoded";

                WebResponse responce = await request.GetResponseAsync();

                string answer = ""; //String.Empty()

                using (Stream s = responce.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(s))
                    {
                        answer = await reader.ReadToEndAsync();
                    }

                }

                responce.Close();

                richTextBox1.Text = answer;

                Forecust.ThreeDaysForecust fCst = JsonConvert.DeserializeObject<Forecust.ThreeDaysForecust>(answer);

                label25.Text = fCst.list[6].dt_txt.ToString();
                label26.Text = fCst.list[14].dt_txt.ToString();
                label27.Text = fCst.list[22].dt_txt.ToString();

                panel1.BackgroundImage = fCst.list[6].weather[0].Icon;
                label1.Text = fCst.list[6].weather[0].main;
                label2.Text = fCst.list[6].weather[0].description;
                label3.Text = "Avg Temperature, Celsium: " + fCst.list[6].main.temp.ToString("0.0");
                label9.Text = "Feels like, Celsium: " + fCst.list[6].main.feels_like.ToString("0.0");
                label4.Text = "Humidity, %: " + fCst.list[6].main.humidity.ToString();
                label5.Text = "Pressure, mm: " + ((int)fCst.list[6].main.pressure).ToString();
                label6.Text = "Speed, km/h: " + ((int)fCst.list[6].wind.speed).ToString();
                label7.Text = "Direction (from): " + fCst.list[6].wind.direction(fCst.list[6].wind.deg);

                panel2.BackgroundImage = fCst.list[14].weather[0].Icon;
                label8.Text = fCst.list[14].weather[0].main;
                label10.Text = fCst.list[14].weather[0].description;
                label11.Text = "Avg Temperature, Celsium: " + fCst.list[14].main.temp.ToString("0.0");
                label12.Text = "Feels like, Celsium: " + fCst.list[14].main.feels_like.ToString("0.0");
                label13.Text = "Humidity, %: " + fCst.list[14].main.humidity.ToString();
                label14.Text = "Pressure, mm: " + ((int)fCst.list[14].main.pressure).ToString();
                label15.Text = "Speed, km/h: " + ((int)fCst.list[14].wind.speed).ToString();
                label16.Text = "Direction (from): " + fCst.list[14].wind.direction(fCst.list[6].wind.deg);

                panel3.BackgroundImage = fCst.list[22].weather[0].Icon;
                label17.Text = fCst.list[22].weather[0].main;
                label18.Text = fCst.list[22].weather[0].description;
                label19.Text = "Avg Temperature, Celsium: " + fCst.list[22].main.temp.ToString("0.0");
                label20.Text = "Feels like, Celsium: " + fCst.list[22].main.feels_like.ToString("0.0");
                label21.Text = "Humidity, %: " + fCst.list[22].main.humidity.ToString();
                label22.Text = "Pressure, mm: " + ((int)fCst.list[22].main.pressure).ToString();
                label23.Text = "Speed, km/h: " + ((int)fCst.list[22].wind.speed).ToString();
                label24.Text = "Direction (from): " + fCst.list[22].wind.direction(fCst.list[6].wind.deg);
            }
            catch // not catch(Exception ex)
            {
                MessageBox.Show("Loading failed...");// not MessageBox.Show(ex.Message);
            }
        }

    }
}
