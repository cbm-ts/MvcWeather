﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWeather.DataAccess.Models
{
    public enum WeatherType
    {
        Sunny,
        Cloudy,
        Rainy,
        Foggy
    }

    public enum TimePeriod
    {
        Morning,
        Afternoon,
        Night
    }

    public class Weather
    {
        public Location Location { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public WeatherType Status { get; set; }
        public TimePeriod TimePeriod { get; set; }
    }
}
