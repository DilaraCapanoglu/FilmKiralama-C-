using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmkiralama.dao
{
    class Musteri
    {
        private int m_id;
        private String m_adi;
        private String m_email;
        private string m_tel;
        private DateTime alis;
        private DateTime veris;
        private double kira; 
            public int M_id
        {
            get {return m_id;}
            set { m_id = value;}
        }

        public string M_adi
        {   get  { return m_adi; }
            set  { m_adi = value;}
        }

        public string M_email
        {
            get { return m_email; }
            set { m_email = value; }
        }
        public string M_tel
        {
            get { return m_tel; }
            set { m_tel = value; }
        }
        public DateTime Alıs {
            get { return alis; }
            set { alis = value; }
        }
        public DateTime Veris
        {
            get { return veris; }
            set { veris = value; }
        }
        public double Kira
        {
            get { return kira; }
            set { kira = value; }
        }

    }
}
