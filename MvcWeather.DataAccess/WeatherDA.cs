using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWeather.DataAccess
{
    public class WeatherDA : BaseDA
    {
        public WeatherDA(Context ctx) : base(ctx) {}
    }
}
