using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.MVC.Lesson__4;

public class MeteoServiceWeather : WeatherServiceCSS
{
    private static readonly Dictionary<string, string> _Pleaces = new(StringComparer.OrdinalIgnoreCase)
    {
        {"moscow","moskva" },
        {"Москва","moskva" },
        {"moskva","moskva" }
    };
    public MeteoServiceWeather(HttpClient Client) : base(Client, "div.temperature span.value") { }

    private const string _UrlTemplate = "https://www.meteoservice.ru/weather/overview/{place}";
 
    protected override string? GetRequestUrl(string Place)
    {
        if (!_Pleaces.TryGetValue(Place, out var place_value))
            return null;

        return _UrlTemplate.Replace("{place}", place_value);
    }

    protected override string ClearString(string DataString) => DataString.TrimEnd('°');


}

