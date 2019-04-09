using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace filmkiralama.Facade
{
    /*
     *   private String m_email;
        private string m_tel;
        private DateTime alis;
        private DateTime veris;
        private double kira;
     * */

    class Musteriİslem
    {

       NpgsqlConnection con=  new NpgsqlConnection("Server =127.0.0.1;Port=5432;User Id=postgres;Password=admin456;Database=FilmKiralama;");
         public void musteriEkle(String m_adi,String m_email,String m_tel,DateTime alis,DateTime veris, double kira)
        {
            NpgsqlCommand sql = new NpgsqlCommand();
            sql.Connection = con;
            con.Open();

            sql.CommandText = "insert into musteri(m_adi,m_email,m_tel,alis,veris,kira) values ('" + m_adi + "', '" + m_email + "', '" + m_tel + "', " + alis + ", " + veris + ", " + kira + ")";
            sql.ExecuteNonQuery();
            con.Close();


        }


    }
}
