using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FilmArsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=FilmArsivim;Integrated Security=True");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select * from TBLFILMLER", baglanti);
            //da.Fill(dt);
            //dataGridView1.DataSource = da;
            
        }

        void Filmler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBLFILMLER", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Filmler();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select AD,LINK from TBLFILMLER", baglanti);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER(AD,KATEGORİ,LINK) values(@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtFilmAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@p3", TxtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşleminiz Gerçekleşti");
            Filmler();
                 
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            webBrowser1.Navigate(link);
        }

        private void BtnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Funda MİNTEMUR tarafından 26.06.2023'de kodlandı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
