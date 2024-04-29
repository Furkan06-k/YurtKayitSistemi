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
    public partial class FrmGelirİstatistik : Form
    {
        public FrmGelirİstatistik()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmGelirİstatistik_Load(object sender, EventArgs e)
        {   //Ödenen para yani kasadaki parayı toplama işelmi (Sum) sql de toplama işlemi
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktar) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
               LblPara.Text = oku[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            //Ayları Tekrarsız olarak getirme işlemi yapıyoruz (distinct) tekrarsız getirme işlemi sql
            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();


            //Grafik tablosuna aylık geliri gösterme 

            SqlCommand komut3 = new SqlCommand("select OdemeAy, sum(odememiktar) from kasa group by OdemeAy", bgl.baglanti());//Ödeme ayı göster karşısında toplam ödenen miktarı göster Ödneen ayıda grupladık
            SqlDataReader oku3=komut3.ExecuteReader();
            while (oku3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku3[0], oku3[1]);
            }
            bgl.baglanti().Close();
        }


        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {   //Combobox da seçilen ayda kaç tl para alınmış toplanmış onu yazdıracagız
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) From Kasa where OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            SqlDataReader oku= komut.ExecuteReader();
            while (oku.Read())
            {
                LblAyKazanc.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }

        
        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
