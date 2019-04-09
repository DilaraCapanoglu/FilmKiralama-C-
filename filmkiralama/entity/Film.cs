using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmkiralama
{
    class Film
    {
        private int film_id;
        private String film_adi;
        private String yönetmen;
        private double süresi;
        private double imdb;


        public int Film_id
        {
            get
            {
                return film_id;
            }
            set
            {
                film_id = value;
            }


        }

        public string Film_adi
        {
            get
            {
                return film_adi;
            }

            set
            {
                film_adi = value;
            }
        }

        public string Yönetmen
        {
            get
            {
                return yönetmen;
            }

            set
            {
                yönetmen = value;
            }
        }

        public double Süresi
        {
            get
            {
                return süresi;
            }

            set
            {
                süresi = value;
            }
        }

        public double Imdb
        {
            get
            {
                return imdb;
            }

            set
            {
                imdb = value;
            }
        }
    }
}
