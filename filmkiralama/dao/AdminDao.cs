using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace filmkiralama
{
    class AdminDao
    {

        private Kullanıcı kullanıcı;
        public Kullanıcı kullanıcıkontrol(String kul_adi, String sifre)
        {

            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = baglanti.Connect();

            komut.CommandText = "SELECT * FROM kullanıcı WHERE kul_adi='" + kul_adi + "' and sifre='" + sifre + "' ";
            baglanti.open();
            NpgsqlDataReader dr = komut.ExecuteReader();

            if (dr.HasRows)
            {
                this.kullanıcı= new Kullanıcı();
                dr.Read();
                this.kullanıcı.Kul_adi = dr["kul_adi"].ToString();
                this.kullanıcı.Sifre= dr["sifre"].ToString();
                baglanti.close();
                return this.kullanıcı;
            }
            else
            {
                baglanti.close();
                return null;
            }

        }
    }

}
