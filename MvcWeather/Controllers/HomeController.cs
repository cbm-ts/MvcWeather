using MvcWeather.DataAccess.Models;
using MvcWeather.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWeather.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            WeatherVM model = new WeatherVM();
            model.Date = DateTime.Now;
            model.ZipCode = 30809;
            return View(model);
        }

        
        public ActionResult FindWeather(WeatherVM model)
        {
            model.ZipCode = 30809;
            model.Location = "Evans, GA";
            model.TodaysWeather = new List<Weather>();
            model.TodaysWeather.Add(
                new Weather
                {
                    Temperature = 70,
                    Status = WeatherType.Sunny,
                    TimePeriod = TimePeriod.Morning
                }
            );
            model.TodaysWeather.Add(
                new Weather
                {
                    Temperature = 95,
                    Status = WeatherType.Rainy,
                    TimePeriod = TimePeriod.Afternoon
                }
            );
            model.TodaysWeather.Add(
                new Weather
                {
                    Temperature = 75,
                    Status = WeatherType.Cloudy,
                    TimePeriod = TimePeriod.Night
                }
            );
            return PartialView("_TodaysWeather", model);
        }
    }
}