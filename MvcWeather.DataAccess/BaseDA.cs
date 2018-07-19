using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWeather.DataAccess
{
    public class BaseDA
    {
        public Context CurrentContext { get; set; }

        public BaseDA(Context ctx)
        {
            CurrentContext = ctx;
        }
    }
}
