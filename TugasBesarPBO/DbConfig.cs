using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesarPBO
{
    internal class DbConfig
    {
        public System.Data.SqlClient.SqlConnection GetConn()
        {
            System.Data.SqlClient.SqlConnection conn =
            new System.Data.SqlClient.SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-4RNVN6O\\SQLEXPRESS;"
            + "Initial Catalog=DBMAHASISWA;"
            + "Integrated Security=True";
            return conn;
        }
        public SqlDataReader GetData(string strsql,
        System.Data.SqlClient.SqlConnection conn)
        {
            SqlDataReader reader = null;
            SqlCommand command = new SqlCommand(strsql, conn);
            command.ExecuteNonQuery();
            reader = command.ExecuteReader();
            return reader;
        }
    }
}
