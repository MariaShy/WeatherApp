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

                int index1 = 8;
                int index2 = index1 + 8;
                int index3 = index2 + 8;

                label25.Text = fCst.list[index1].dt_txt.ToString();
                label26.Text = fCst.list[index2].dt_txt.ToString();
                label27.Text = fCst.list[index3].dt_txt.ToString();

                panel1.BackgroundImage = fCst.list[index1].weather[0].Icon;
                label1.Text = fCst.list[index1].weather[0].main;
                label2.Text = fCst.list[index1].weather[0].description;
                label3.Text = "Avg Temperature, Celsium: " + fCst.list[index1].main.temp.ToString("0.0");
                label9.Text = "Feels like, Celsium: " + fCst.list[index1].main.feels_like.ToString("0.0");
                label4.Text = "Humidity, %: " + fCst.list[index1].main.humidity.ToString();
                label5.Text = "Pressure, mm: " + ((int)fCst.list[index1].main.pressure).ToString();
                label6.Text = "Speed, km/h: " + ((int)fCst.list[index1].wind.speed).ToString();
                label7.Text = "Direction (from): " + fCst.list[index1].wind.direction(fCst.list[index1].wind.deg);

                panel2.BackgroundImage = fCst.list[index2].weather[0].Icon;
                label8.Text = fCst.list[index2].weather[0].main;
                label10.Text = fCst.list[index2].weather[0].description;
                label11.Text = "Avg Temperature, Celsium: " + fCst.list[index2].main.temp.ToString("0.0");
                label12.Text = "Feels like, Celsium: " + fCst.list[index2].main.feels_like.ToString("0.0");
                label13.Text = "Humidity, %: " + fCst.list[index2].main.humidity.ToString();
                label14.Text = "Pressure, mm: " + ((int)fCst.list[index2].main.pressure).ToString();
                label15.Text = "Speed, km/h: " + ((int)fCst.list[index2].wind.speed).ToString();
                label16.Text = "Direction (from): " + fCst.list[index2].wind.direction(fCst.list[index2].wind.deg);

                panel3.BackgroundImage = fCst.list[index3].weather[0].Icon;
                label17.Text = fCst.list[index3].weather[0].main;
                label18.Text = fCst.list[index3].weather[0].description;
                label19.Text = "Avg Temperature, Celsium: " + fCst.list[index3].main.temp.ToString("0.0");
                label20.Text = "Feels like, Celsium: " + fCst.list[index3].main.feels_like.ToString("0.0");
                label21.Text = "Humidity, %: " + fCst.list[index3].main.humidity.ToString();
                label22.Text = "Pressure, mm: " + ((int)fCst.list[index3].main.pressure).ToString();
                label23.Text = "Speed, km/h: " + ((int)fCst.list[index3].wind.speed).ToString();
                label24.Text = "Direction (from): " + fCst.list[index3].wind.direction(fCst.list[index3].wind.deg);
            }
            catch // not catch(Exception ex)
            {
                MessageBox.Show("Loading failed...");// not MessageBox.Show(ex.Message);
            }
        }

    }
}
