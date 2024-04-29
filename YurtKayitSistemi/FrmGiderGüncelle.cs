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
    public partial class FrmGiderGüncelle : Form
    {
        public FrmGiderGüncelle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        //Yine alanlartı tanımlayıp yazdıracagız figer listesi formunda datagride hangi alan seçildiyse burada yazdıracagız
        public string elektrik, su, dogalgaz, gida, diğer, personel, internet,id;
        private void FrmGiderGüncelle_Load(object sender, EventArgs e)
        {   //Yazdırdık
            TxtGiderid.Text = id;
            TxtDiger.Text = diğer;
            TxtDogalGaz.Text = dogalgaz;
            TxtElektrik.Text = elektrik;
            TxtGida.Text = gida;
            TxtInternet.Text = internet;
            TxtPersonel.Text = personel;
            TxtSu.Text = su;
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {//Gider Güncelleme Alanı
            try
            {
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1,Su=@p2,Dogalgaz=@p3,internet=@p4,Gıda=@p5,Personel=@p6,Diger=@p7 where Odemeid=@p8", bgl.baglanti());
                komut.Parameters.AddWithValue("@p8", TxtGiderid.Text);
                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalGaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGida.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider Güncellendi");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Gider Güncellenemedi");
            }
        }
    }
}
