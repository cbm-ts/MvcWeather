using MvcWeather.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcWeather.Models.ViewModels
{
    public class WeatherVM
    {
        public int ZipCode { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public WeatherType Status { get; set; }
        public List<Weather> TodaysWeather { get; set; }
    }
}