using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWeather.DataAccess.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
