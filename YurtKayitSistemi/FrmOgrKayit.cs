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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {   //Bölümleri Listeleme Komutları
            SqlCommand komut = new SqlCommand("Select BolumAd From Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());//Combobox da bölümleri gösterme
            }
            bgl.baglanti().Close();

            //Boş Odaları Listeleme
            SqlCommand komut2 = new SqlCommand("Select Odano From Odalar where OdaKapasite != OdaAktif", bgl.baglanti());//Boş Odaları göstermek için odakapasitesi odadaki kişileri eşit olmayanları getir dedik 
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read()) 
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {   //Öğrenci Bigilerini Kaydetme
            try
            {
                SqlCommand komutkaydet = new SqlCommand("insert into Ogrenci (OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdano,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres)values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p3", MskTC.Text);
                komutkaydet.Parameters.AddWithValue("@p4", MskOgrTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p10", MskVeliTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text);
                komutkaydet.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Öğrenci Kaydı Başarılı Bir Şekilde Gerçekleştirildi");


                //Öğrenci id yi label a çekme
                SqlCommand komut=new SqlCommand("select Ogrid from Ogrenci",bgl.baglanti());
                SqlDataReader oku=komut.ExecuteReader();
                while (oku.Read())
                {
                    label12.Text = oku[0].ToString();
                }
                bgl.baglanti().Close();


                //Öğrenci Borçlar Alanı Oluşturma
                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid,OgrAd,OgrSoyad) values (@b1,@b2,@b3)",bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", label12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                komutkaydet2.ExecuteNonQuery();           
                bgl.baglanti().Close();
            }
            catch (Exception)
            {
                MessageBox.Show("HATA!!! Lütfen Yeniden Deneyiniz");
            }
            //Öğrenci Oda Kontenjanı Arttırma yani bir öğrenci bir odaya kayıt oldugu zaman oda daki kalan kişi sayısı artacak aktif odalar için

            SqlCommand komutoda = new SqlCommand("update Odalar set OdaAktif=OdaAktif+1 where OdaNo=@oda1", bgl.baglanti());//update Odalar set OdaAktif=OdaAktif+1 burda bütün odalrı +1 eklicekti biz seçilen oda deidk where komutu ile seçilen odayı 1 arttırdık
            komutoda.Parameters.AddWithValue("@oda1",CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close() ;
        }
    }
}
