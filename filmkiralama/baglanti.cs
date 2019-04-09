using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace filmkiralama
{
    class baglanti
    {
        public static NpgsqlConnection cn;
        private baglanti()
        {
        }
        private static baglanti b = null;
        private static baglanti GetInstance()
        {
            if (b == null)
            {
                b = new baglanti();
                return b;
            }
            else
                return b;

        }

        private static NpgsqlConnection connect()
        {
            if (cn == null)
            {
                cn = new NpgsqlConnection("Server =127.0.0.1;Port=5432;User Id=postgres;Password=admin456;Database=FilmKiralama;");
                return cn;
            }
            else

                return cn;

        }
        public static NpgsqlConnection Connect()
        {
            return connect();
        }

        public static void open()
        {
            cn.Open();
        }
        public static void close()
        {
            cn.Close();
        }

    }

}
