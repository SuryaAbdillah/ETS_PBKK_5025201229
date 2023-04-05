using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ETS_converter
{
    internal class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data source=SURYA\\SQLEXPRESS; initial catalog=DB_CURRENCY;integrated security=true";
            return Conn;
        }
    }
}
