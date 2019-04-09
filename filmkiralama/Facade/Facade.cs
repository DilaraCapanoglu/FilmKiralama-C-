using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace filmkiralama.Facade
{
    class Facade
    {
        MusteriControl m1 = new MusteriControl();
        Musteriİslem m2 = new Musteriİslem();
       


        public void M2UyeEkle(String m_adi, String m_email, String m_tel, DateTime alis, DateTime veris, double kira)
        {
            if (m1.borclu(m_email) == false)
            {
                m2.musteriEkle(m_adi, m_email, m_tel, alis, veris, kira);
            }
            else
            {
                MessageBox.Show("Film Kiralayamazsın!!");
            }
        }

        public bool M2Girisİzni(String m_email)
        {
            if (m1.borclu(m_email) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
