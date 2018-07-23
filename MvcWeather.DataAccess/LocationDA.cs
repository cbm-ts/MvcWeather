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
    public class LocationDA : BaseDA
    {
        public LocationDA(Context ctx) : base(ctx) { }

        public string GetLocationByZip(string zipCode, DateTime date)
        {
            Location location = new Location();
            string commandText =
@"SELECT
     l.LocationID
    ,l.City
    ,l.State
FROM Location
WHERE l.ZipCode = @ZipCode";
            using (SqlCommand cmd = new SqlCommand(commandText, CurrentContext.Connection))
            {
                cmd.Parameters.Add(new SqlParameter("@Zip", zipCode));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        location.LocationID = reader.GetInt32(0);
                        location.City = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        location.State = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                    }
                }
            }

            return location.ToString();
        }
    }
}
