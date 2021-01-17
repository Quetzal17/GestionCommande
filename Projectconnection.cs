using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OSAO
{
    class Projectconnection
    {
        public static MySqlConnection con = null;
        public void Connectiono_Today()
        {
            con = new MySqlConnection("server=127.0.0.1; port=3308; uid=root; database=osa");
            con.Open();
        }
    }
}
