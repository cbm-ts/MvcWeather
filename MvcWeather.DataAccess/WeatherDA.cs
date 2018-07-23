using MvcWeather.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWeather.DataAccess
{
    public class WeatherDA : BaseDA
    {
        public WeatherDA(Context ctx) : base(ctx) { }

        public List<Weather> GetTodaysWeatherByZip(int zipCode, DateTime date)
        {
            List<Weather> todaysWeather = new List<Weather>();
            string commandText =
@"SELECT
     w.Temperature
    ,w.Status
    ,w.TimePeriod
    ,w.Date
FROM Weather
INNER JOIN Location
    ON l.LocationID = w.LocationID
WHERE l.ZipCode = @ZipCode
    AND w.Date = @Date";
            using (SqlCommand cmd = new SqlCommand(commandText, CurrentContext.Connection))
            {
                cmd.Parameters.Add(new SqlParameter("@Zip", zipCode));
                cmd.Parameters.Add(new SqlParameter("@Date", date));

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Weather weather = new Weather();
                        weather.Temperature = reader.IsDBNull(0) ? 0 : reader.GetInt32(2);
                        weather.Status = reader.IsDBNull(1) ? 0 : (WeatherType)Enum.Parse(typeof(WeatherType), reader.GetString(1));
                        weather.TimePeriod = reader.IsDBNull(2) ? 0 : (TimePeriod)Enum.Parse(typeof(TimePeriod), reader.GetString(2));
                        weather.Date = reader.IsDBNull(3) ? date : reader.GetDateTime(3);
                        todaysWeather.Add(weather);
                    }
                }
            }

            return todaysWeather;
        }
    }
}
