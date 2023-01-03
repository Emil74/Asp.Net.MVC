using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net.MVC.Lesson__4;

public abstract class WeatherService : ISynoptic
{
    public abstract double GetTemperature(string Place);
}

public interface ISynoptic
{
    double GetTemperature(string Place);
}
