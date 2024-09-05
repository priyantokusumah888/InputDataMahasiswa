using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesarPBO
{
    internal class Mst_User
    {
        public string username { get; set; }
        public string password { get; set; }
        public SqlDataReader GetDataUser(System.Data.SqlClient.SqlConnection conn)
        {
            DbConfig db = new DbConfig();
            SqlDataReader reader = null;
            String strsql = "SELECT * FROM login";
            reader = db.GetData(strsql, conn);
            return reader;
        }
        public SqlDataReader GetDataUserLogin(System.Data.SqlClient.SqlConnection conn)
        {
            DbConfig db = new DbConfig();
            SqlDataReader reader = null;
            String strsql = "SELECT * FROM login WHERE username='" + username + "'";
            reader = db.GetData(strsql, conn);
            return reader;

        }
    }
}
