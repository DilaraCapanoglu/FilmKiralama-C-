using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filmkiralama
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtgiris_Click(object sender, EventArgs e)
        {
            Kullanıcı kl = new Kullanıcı();
            kl.Kul_adi = txtkul_adi.Text;
            kl.Sifre = txtsifre.Text;

            AdminDao aDao = new AdminDao();
            var kontrol = aDao.kullanıcıkontrol(kl.Kul_adi, kl.Sifre);

            if (kontrol != null)
            {
                AraForm flmForm = new AraForm();
                flmForm.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("KULLANICI ADI VEYA ŞİFRE YANLIŞ!!!!!");
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }
    }
    }

