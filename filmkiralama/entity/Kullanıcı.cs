using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmkiralama
{
    class Kullanıcı
    {
        private int kul_id;
        private String kul_adi;
        private String sifre;

        public int Kul_id
        {
            get
            {
                return kul_id;
            }

            set
            {
                kul_id = value;
            }
        }

        public string Kul_adi
        {
            get
            {
                return kul_adi;
            }

            set
            {
                kul_adi = value;
            }
        }

        public string Sifre
        {
            get
            {
                return sifre;
            }

            set
            {
                sifre = value;
            }
        }
    }
}
