using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using filmkiralama.dao;
using filmkiralama.Strategy;
using filmkiralama.entity;
using filmkiralama.Facade;
namespace filmkiralama
{
    public partial class MusteriKayıt : Form
    {
        MusteriDao md = new MusteriDao();

        public MusteriKayıt()
        {
            InitializeComponent();
        }
       
        private void MusteriKayıt_Load(object sender, EventArgs e)
        {
            textBox1.Text = AnaForm.flm;
            textBox6.Text = AnaForm.yon;
        }

       private void button2_Click(object sender, EventArgs e)
        {
           // entity.Musteri musteriekle = new entity.Musteri();
            Musteri musteriekle = new Musteri();
         //   musteriekle.M_id = Convert.ToInt32(textBox1.Text);
            musteriekle.M_adi = textBox2.Text;
            musteriekle.M_email = textBox3.Text;
            musteriekle.M_tel = textBox4.Text;

            musteriekle.Alıs = Convert.ToDateTime(dateTimePicker1.Text);
            musteriekle.Veris = Convert.ToDateTime(dateTimePicker2.Text);
            musteriekle.Kira = Convert.ToDouble(textBox5.Text);
            facade f = new facade();

            if (f.M2Girisİzni(musteriekle.M_email) == true)
            {
                MusteriDao mdao = new MusteriDao();
                var check = mdao.musteriCheck(musteriekle.M_adi, musteriekle.M_email, musteriekle.M_tel, musteriekle.Alıs, musteriekle.Veris, musteriekle.Kira);

                if (check != null)
                {
                    MessageBox.Show("Kaydolundunuz!!");
                }
                else
                {
                    MessageBox.Show("Film Kiralayamzsınız");
                }


            }
           md.MusteriEkle(musteriekle);
            MessageBox.Show("Bizi tercih ettiğiniz için teşekkurler");
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hesap;

            hesap = (int)(dateTimePicker2.Value.ToOADate() - dateTimePicker1.Value.ToOADate());
           
                DateTime t1 = dateTimePicker1.Value.Date;
                DateTime t2 = dateTimePicker2.Value.Date;

             var fark = t2 - t1;
            if (fark.Days <= 30)
            {
                StrategyKiralama k = new kiralama_gun();
                StrategyContext con = new StrategyContext(k);
                textBox5.Text = Convert.ToString(con.contex(hesap));
               
            }
            else if(fark.Days >30 && fark.Days <= 365)
            {
                StrategyKiralama k = new kiralama_ay();
                StrategyContext con = new StrategyContext(k);
                textBox5.Text = Convert.ToString(con.contex(hesap));
            }
            else if (fark.Days>365){
                StrategyKiralama k = new kiralama_yıl();
                StrategyContext con = new StrategyContext(k);
                textBox5.Text = Convert.ToString(con.contex(hesap));
            }
           
        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //}
    }
}
