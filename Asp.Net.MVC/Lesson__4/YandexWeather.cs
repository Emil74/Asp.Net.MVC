using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Asp.Net.MVC.Lesson__4;

public class YandexWeather : WeatherServiceCSS
{
    private static readonly Dictionary<string, string> _Pleaces = new(StringComparer.OrdinalIgnoreCase)
    {
        {"moscow","moscow" },
        {"Москва","moscow" },
        {"moskva","moscow" }
    };
    public YandexWeather(HttpClient Client)
        : base(Client, "div.temp span.temp__value_with-unit") { }

    private const string _UrlTemplate = "https://yandex.ru/pogoda/{place}";

    protected override string? GetRequestUrl(string Place)
    {
        if (!_Pleaces.TryGetValue(Place, out var place_value))
            return null;

        return _UrlTemplate.Replace("{place}", place_value);
    }
}

