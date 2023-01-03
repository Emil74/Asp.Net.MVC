using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.MVC.Lesson__4
{
    internal class Work_4
    {
        public static void Run()
        {
            var rnd = new Random();
            var today = DateTime.Today;
            var user_agent = string.Format("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:{0}.0) Gecko/{2}{3:00}{4:00} Firefox/{0}.0.{1}",
                rnd.Next(3, 10),
                rnd.Next(1, 10),
                rnd.Next(today.Year - 4, today.Year),
                rnd.Next(12),
                rnd.Next(30));

            var client = new HttpClient()
            {
                DefaultRequestHeaders = { { "User-Agent", user_agent } }
            };


            #region Variant1


            /* 

              var response = client.GetAsync("https://yandex.ru/pogoda/moscow").Result;

              var html = response.
                               EnsureSuccessStatusCode().
                               Content.
                               ReadAsStringAsync().
                               Result;

              var parser = new HtmlParser();
              var doc = parser.ParseDocument(html);

              var temp_node = doc.QuerySelector("div.temp span.temp__value_with-unit");
              var temp_str = temp_node.InnerHtml;
              var temp = double.Parse(temp_str);*/
            #endregion


            #region Variant2

            //var yandex = new YandexWeather(client);

            //var t1 = yandex.GetTemperature();

            var mail = new MailRuWeatherService(client);
            WatchForWeather(mail, "Москва", 2500);

            var t2 = mail.GetTemperature("moscow");

           // Console.WriteLine("MailWeather: " + t2 + "°");
            #endregion

            #region Variant3

            var meteo_service = new MeteoServiceWeather(client);
            var t3 = meteo_service.GetTemperature("Москва");
           // Console.WriteLine("MeteoServiceWeather: " + t3 + "°");
            #endregion
        }
        static void WatchForWeather(ISynoptic Synoptic, string Place, int Timeout)
        {
            while (true)
            {
                var t = Synoptic.GetTemperature(Place);
                Console.WriteLine("{0} {1: HH:mm:ss.ff} - {2}°",Place, DateTime.Now, t);
                Thread.Sleep(Timeout);
            }
        }
    }
}
