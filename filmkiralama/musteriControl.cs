using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace filmkiralama
{
    class musteriControl
 
      
        {
            NpgsqlConnection con = new NpgsqlConnection("Server =127.0.0.1;Port=5432;User Id=postgres;Password=admin456;Database=FilmKiralama;");
            public bool borclu(String m_email)
            {
                NpgsqlCommand komut = new NpgsqlCommand();
                komut.Connection = con;

                komut.CommandText = "select * from borclu where m_email='" + m_email + "' ";
                con.Open();
                NpgsqlDataReader dr = komut.ExecuteReader();
                if (dr.HasRows)
                {
                    return true;
                    con.Close();
                }
                else
                {
                    con.Close();
                    return false;
                }

            }
        }
}
