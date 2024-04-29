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

namespace YurtKayitSistemi
{
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        private void button1_Click(object sender, EventArgs e)
        {   //Admin giriş işlemleri
            SqlCommand komut = new SqlCommand("select * from admin where yoneticiad=@p1 and yoneticisifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hata Kullanıcı Adı Ya Da Şifre Yanlış");
                TxtKullaniciAd.Clear();//Hatadan sonra textboxları temizlettik
                TxtSifre.Clear();
                TxtKullaniciAd.Focus();//Ve kullanıcı adından başlattık imleci
            }
            bgl.baglanti().Close();
        }
    }
}
