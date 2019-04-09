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
namespace filmkiralama
{
    public partial class MusteriCrud : Form
    {
        MusteriDao md = new MusteriDao();
        public MusteriCrud()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void listele()
        {
            MusteriDao musteriDao = new MusteriDao();
            dataGridView1.DataSource = musteriDao.findAll();
        }
        private void MusteriCrud_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri = (Musteri)dataGridView1.CurrentRow.DataBoundItem;
            md.musteriSil(musteri);
            listele();
        }
    }
}
