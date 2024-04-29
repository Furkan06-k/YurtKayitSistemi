using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace YurtKayitSistemi
{
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet.Bolumler' table. You can move, or remove it, as needed.
            this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);

        }

        private void PcbBolumEkle_Click(object sender, EventArgs e)
        {   //Bölüm ekleme işlemi
            try
            {
                SqlCommand komut1 = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Başarı İle Eklnedi");
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);//Ekledikden sonra bölümleri tekrardan gösterdik
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu Yeniden Deneyiniz");
            }
        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {   //Bölüm Silme
            try
            {
                SqlCommand komut2 = new SqlCommand("delete from Bolumler where Bolumid=@p1", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxBolumid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Başarılı Bir Şekilde Silindi");
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu Yeniden Deneyiniz");
            }
        }

        int secilen;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {   //Bölüme tıklandığında verileri textboxlarda gösterme işlemi
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            TxBolumid.Text= id;
            TxtBolumAd.Text= bolumad;
        }

        private void PcbBolumDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut3 = new SqlCommand("update  Bolumler Set Bolumad=@p1 where Bolumid=@p2", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p2", TxBolumid.Text);
                komut3.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Başarılı Bir Şekilde Güncellendi");
                this.bolumlerTableAdapter.Fill(this.yurtKayitDataSet.Bolumler);
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu Yeniden Deneyiniz");
            }
        }
    }
}
