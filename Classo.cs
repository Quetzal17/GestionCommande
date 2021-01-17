using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace OSAO
{
    class Classo
    {
        public static MySqlConnection cons = null;
        public void connexion_today()
        {
            cons = new MySqlConnection("SERVER=160.153.128.30;PORT=3306;DATABASE=AbrahamALL;UID=OSA; PASSWORD=OSA2020;");
            cons.Open();
        }
    }
}
