using MvcWeather.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcWeather.DataAccess
{
    public class Context : IDisposable
    {
        private SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection(ConfigurationSettings.ConnectionString);

                return _connection;
            }
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
    }
}
