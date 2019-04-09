using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
namespace filmkiralama.dao
{
    class MusteriDao
    {
        private Musteri musteri;

        internal Musteri Musteri
        {
            get
            {
                return musteri;
            }

            set
            {
                musteri = value;
            }
        }
        public void MusteriEkle(Musteri k)
        {
            try
            {
                NpgsqlCommand sql = new NpgsqlCommand();

                sql.Connection = baglanti.Connect();
                baglanti.open();
                sql.CommandText = "Insert Into musteri (m_adi,m_email,m_tel,alis,veris,kira)" +
                    " Values ('" + k.M_adi + "','" + k.M_email + "','" + k.M_tel + "','"
                   + k.Alıs + "','" + k.Veris + "'," + k.Kira + ")";
                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            baglanti.close();
          //  MessageBox.Show("Bizi tercih ettiğiniz için teşekkurler");
            
            findAll();

        }


        public Musteri musteriCheck(String m_adi, String m_email, String m_tel, DateTime alis, DateTime veris, double kira)
        {
            NpgsqlCommand komut = new NpgsqlCommand();
            komut.Connection = baglanti.Connect();
            komut.CommandText = "select * from borclu m_adi='" + m_adi + "' and m_email='" + m_email + "' and m_tel='" + m_tel + " ' and alis='" + alis + "' and veris='" +veris+ " 'and kira=";
            baglanti.open();
            NpgsqlDataReader dr = komut.ExecuteReader();
            if (dr.HasRows)
            {
                this.musteri = new Musteri();
                dr.Read();
                this.musteri.M_adi = dr["m_adi"].ToString();
                this.musteri.M_email = dr["m_email"].ToString();
                this.musteri.M_tel = dr["m_tel"].ToString();
                this.musteri.Alıs = DateTime.Parse(dr["alis"].ToString());
                this.musteri.Veris = DateTime.Parse(dr["veris"].ToString());
                this.musteri.Kira = double.Parse(dr["kira"].ToString());
                baglanti.close();
                return this.musteri;

            }
            else
            {
                baglanti.close();
                return null;
            }



        }
        public void musteriSil(Musteri k)
        {
            try
            {
                if (MessageBox.Show("Silmek İstediğinize Emin Misiniz???", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NpgsqlCommand sql = new NpgsqlCommand();

                    sql.Connection = baglanti.Connect();
                    baglanti.open();
                    sql.CommandText = "delete from musteri where m_id=" + k.M_id + "";

                    sql.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            baglanti.close();
            MessageBox.Show("Silme Tamamlandı");

            findAll();
        }
        public List<Musteri> findAll()
        {
            try
            {
                List<Musteri> musteriList = new List<Musteri>();

                NpgsqlCommand sql = new NpgsqlCommand();


                sql.Connection = baglanti.Connect();
                sql.CommandText = "select * from musteri";
                baglanti.open();
                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {
                    this.musteri = new Musteri();

                    musteri.M_id = int.Parse(dr["m_id"].ToString());
                    musteri.M_adi = (dr["m_adi"].ToString());
                    musteri.M_email = (dr["m_email"].ToString());
                    musteri.M_tel = (dr["m_tel"].ToString());
                    musteri.Alıs = DateTime.Parse(dr["alis"].ToString());
                    musteri.Veris = DateTime.Parse(dr["veris"].ToString());
                    musteri.Kira = double.Parse(dr["kira"].ToString());

                    musteriList.Add(musteri);
                }
                baglanti.close();
                return musteriList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Musteri>();
            }

        }
    }
}
