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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = Mustafa; Initial Catalog = PersonelVeriTabani; Integrated Security = True");

        private void btn_giris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("Select * From Tbl_Yonetici Where KullaniciAd=@p1 and Sifre=@p2", baglanti);
            sorgu.Parameters.AddWithValue("@p1", txt_kul_adi.Text);
            sorgu.Parameters.AddWithValue("@p2", txt_sifre.Text);
            SqlDataReader dr1= sorgu.ExecuteReader();
            if (dr1.Read())
            {
                FrmAnaForm frm = new FrmAnaForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("HATALI GİRİŞ YAPTINIZ!!!");
            }

            baglanti.Close();
        }

        private void txt_kul_adi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
