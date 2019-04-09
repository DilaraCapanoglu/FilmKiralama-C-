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
using filmkiralama.entity;
using Npgsql;

namespace filmkiralama
{
    public partial class FilmForm : Form
    {
        public FilmForm()
        {
            InitializeComponent();
        }
       
        Film film = new Film();
        FilmDao fk = new FilmDao();
        private void FilmForm_Load(object sender, EventArgs e)
        {
            listele();
           
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            txtfilmadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtyönetmen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtsüre.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtimdb.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString() ;
     
        }
       
        private void btnekle_Click(object sender, EventArgs e)
        {
            Film filmekle = new Film();
         
            filmekle.Film_adi = txtfilmadi.Text;
            filmekle.Yönetmen = txtyönetmen.Text;

            filmekle.Süresi = Convert.ToInt32(txtsüre.Text);
            filmekle.Imdb = Convert.ToDouble(txtimdb.Text);

            fk.filmEkle(filmekle);
            listele();

        }

        private void btngnclle_Click(object sender, EventArgs e)
        {

            Film eski = new Film();
            eski = (Film)dataGridView1.CurrentRow.DataBoundItem;
            Film yeni = new Film();
        
            yeni.Film_adi = txtfilmadi.Text;
            yeni.Yönetmen = txtyönetmen.Text;
            yeni.Süresi = Convert.ToInt32(txtsüre.Text);
            yeni.Imdb = Convert.ToDouble(txtimdb.Text);
            fk.filmGüncelle(eski, yeni);
            listele();
           
          
        }
       
        private void btnsil_Click(object sender, EventArgs e)
        {

              Film film= new Film();
            film = (Film)dataGridView1.CurrentRow.DataBoundItem;
            fk.filmSil(film);
            listele();

        }
       
        public void listele()
        {
            FilmDao filmDao = new FilmDao();
            dataGridView1.DataSource = filmDao.findAll();
        }
        private void temizleme()
        {

      
            txtfilmadi.Text = "";
            txtyönetmen.Text = "";
            txtsüre.Text = "";
            txtimdb.Text = "";
        

        }
        public void setet(int film_id, string film_adi, string yönetmen, int süresi, int imdb)
        {
            this.film.Film_id=film_id;
            this.film.Film_adi=film_adi;
            this.film.Yönetmen = yönetmen;
            this.film.Süresi = süresi;
            this.film.Imdb = imdb;
        }

       
        
    }
}
