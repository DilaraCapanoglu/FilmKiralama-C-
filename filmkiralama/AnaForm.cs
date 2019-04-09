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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }
        public static string flm;
        public static string yon;
        private void button2_Click(object sender, EventArgs e)
        {  yon = dataGridView3.CurrentRow.Cells[0].Value.ToString();
             flm = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            flm = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            yon = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = flm.ToString();
            textBox2.Text = yon.ToString();
            MusteriKayıt mk = new MusteriKayıt();
            mk.Show();
       

        }


      
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        public void listele()
        {
            FilmDao filmDao = new FilmDao();
            dataGridView3.DataSource = filmDao.findAll();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminForm af = new AdminForm();
            af.Show();
        }
    }
}
