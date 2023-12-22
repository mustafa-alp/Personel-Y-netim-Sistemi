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

namespace sql_calısma_2
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
            
        }

        void temizle()
        {
            txt_per_id.Text = "";
            txt_adi.Text = "";
            txt_soyadi.Text = "";
            txt_meslek.Text = "";
            cmb_sehri.Text = "";
            msk_maas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txt_adi.Focus();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = Mustafa; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet1.Tbl_Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1",txt_adi.Text);
            komut.Parameters.AddWithValue("@p2",txt_soyadi.Text);
            komut.Parameters.AddWithValue("@p3",cmb_sehri.Text);
            komut.Parameters.AddWithValue("@p4", msk_maas.Text);
            komut.Parameters.AddWithValue("@p5",txt_meslek.Text);
            komut.Parameters.AddWithValue("@p6",label3.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yeni kişi eklendi!!");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btn_listele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label3.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                label3.Text="False";
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView1.SelectedCells[0].RowIndex;
            txt_per_id.Text=dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txt_adi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txt_soyadi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmb_sehri.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msk_maas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();  
            txt_meslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            if (label3.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label3.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btn_sil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where PerID=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",txt_per_id.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi!!");
        }

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 Where PerID=@a7 ", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1",txt_adi.Text);
            komutguncelle.Parameters.AddWithValue("@a2",txt_soyadi.Text);
            komutguncelle.Parameters.AddWithValue("@a3", cmb_sehri.Text);
            komutguncelle.Parameters.AddWithValue("@a4", msk_maas.Text);
            komutguncelle.Parameters.AddWithValue("@a5",label3.Text);
            komutguncelle.Parameters.AddWithValue("@a6",txt_meslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7",txt_per_id.Text);
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");
        }

        private void btn_istatislik_Click(object sender, EventArgs e)
        {
            Frmistatislik fr = new Frmistatislik();
            fr.Show();
        }

        private void btn_grafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler(); 
            frg.Show();
        }
    }
}
