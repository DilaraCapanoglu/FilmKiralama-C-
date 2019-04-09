using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace filmkiralama
{
    class FilmDao
    {
       private Film film;

        internal Film Film
        {
            get
            {
                return film;
            }

            set
            {
                film = value;
            }
        }
     
        public void filmGüncelle(Film eski, Film yeni)
        {

            try
            {
                NpgsqlCommand sql = new NpgsqlCommand();

                sql.Connection = baglanti.Connect();
                baglanti.open();
                //  sql.CommandText = "Update film SET film_id='" + yeni.Film_id + "',film_adi='" + yeni.Film_adi + "',yönetmen='" + yeni.Yönetmen + "',süresi='" + yeni.Süresi + "',imdb='" + yeni.Imdb + "' Where film_id=" + eski.Film_id + "";
                sql.CommandText = "Update film SET film_adi='" + yeni.Film_adi + "',yönetmen='" + yeni.Yönetmen + "',süresi='" + yeni.Süresi + "',imdb='" + yeni.Imdb + "' Where film_id=" + eski.Film_id + "";

                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            baglanti.close();
           
            findAll();
        }

        public void filmSil(Film k)
        {
            try
            {
                if (MessageBox.Show("Silmek İstediğinize Emin Misiniz???", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NpgsqlCommand sql = new NpgsqlCommand();

                    sql.Connection = baglanti.Connect();
                    baglanti.open();
                    sql.CommandText = "delete from film where film_id=" + k.Film_id + "";

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
    
        public void filmEkle(Film k)
        {
            try
            {
                NpgsqlCommand sql = new NpgsqlCommand();

                sql.Connection = baglanti.Connect();
                baglanti.open();
                sql.CommandText = "Insert Into film (film_adi,yönetmen,süresi,imdb)" +
                    " Values ('"  + k.Film_adi + "','" + k.Yönetmen + "',"
                   + k.Süresi + "," + k.Imdb + ")";
                sql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            baglanti.close();
           
            findAll();
           
        }
        

        public List<Film> findAll()
        {
            try
            {
                List<Film> filmList = new List<Film>();

                NpgsqlCommand sql = new NpgsqlCommand();

                
                sql.Connection = baglanti.Connect();
                sql.CommandText = "select * from film";
                baglanti.open();
                NpgsqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {
                    this.film = new Film();

                    film.Film_id = int.Parse(dr["film_id"].ToString());
                    film.Film_adi = (dr["film_adi"].ToString());
                    film.Yönetmen = (dr["yönetmen"].ToString());
                    film.Süresi = double.Parse(dr["süresi"].ToString());
                    film.Imdb = double.Parse(dr["imdb"].ToString());

                    filmList.Add(film);
                }
                baglanti.close();
                return filmList;
            }
            catch (Exception ex)
            {
               
                return new List<Film>();
            }

        }
}
    }
    