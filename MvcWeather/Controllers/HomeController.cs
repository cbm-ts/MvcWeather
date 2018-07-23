using MvcWeather.DataAccess;
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
            return View(new WeatherVM());
        }

        
        public ActionResult FindWeather(WeatherVM model)
        {
            model.Date = DateTime.Now;
            using (Context ctx = new Context())
            {
                LocationDA locationDA = new LocationDA(ctx);
                model.Location = locationDA.GetLocationByZip(model.ZipCode);
                WeatherDA weatherDA = new WeatherDA(ctx);
                model.TodaysWeather = weatherDA.GetTodaysWeatherByZip(model.ZipCode, model.Date);
            }

            //model.ZipCode = 30809;
            //model.Location = "Evans, GA";
            //model.TodaysWeather = new List<Weather>();
            //model.TodaysWeather.Add(
            //    new Weather
            //    {
            //        Temperature = 70,
            //        Status = WeatherType.Sunny,
            //        TimePeriod = TimePeriod.Morning
            //    }
            //);
            //model.TodaysWeather.Add(
            //    new Weather
            //    {
            //        Temperature = 95,
            //        Status = WeatherType.Rainy,
            //        TimePeriod = TimePeriod.Afternoon
            //    }
            //);
            //model.TodaysWeather.Add(
            //    new Weather
            //    {
            //        Temperature = 75,
            //        Status = WeatherType.Cloudy,
            //        TimePeriod = TimePeriod.Night
            //    }
            //);
            return PartialView("_TodaysWeather", model);
        }
    }
}