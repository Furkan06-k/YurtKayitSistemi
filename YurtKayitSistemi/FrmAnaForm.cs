using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'yurtKayitDataSet1.Ogrenci' table. You can move, or remove it, as needed.
            this.ogrenciTableAdapter.Fill(this.yurtKayitDataSet1.Ogrenci);
            timer1.Start();//timer çalıştırdık
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();//Uzun tarih formatında veri çektik
            label2.Text = DateTime.Now.ToLongTimeString();//Uzun saat formatında veri çektik
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Uygulamıza hesap makinası ekledik bu gibi exe dosyalarını Diagnostics komutu ile ekliyoruz
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Paint ekleme işlemi
            System.Diagnostics.Process.Start("MsPaint.exe");
        }

        private void radyo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Radyo ekleme işlemi
            axWindowsMediaPlayer1.URL = "https://www.kralmuzik.com.tr/radyo/kral-pop";//Radyo uzantısını yazınca çalışıyor ama ben uzantı bulamadım 
        }

        private void radyo2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://www.kralmuzik.com.tr/radyo/kral-pop";//Radyo uzantısını yazınca çalışıyor ama ben uzantı bulamadım 
        }

        private void radyo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "https://www.kralmuzik.com.tr/radyo/kral-pop";//Radyo uzantısını yazınca çalışıyor ama ben uzantı bulamadım 
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrKayit fr = new FrmOgrKayit();
            fr.Show();
        }

        private void öğrenciSilToolStripMenuItem_Click(object sender, EventArgs e)
        {   //Öğrenci Listele alanı burası başlık yanlış
            FrmOgrListe fr =new FrmOgrListe();
            fr.Show();
        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            FrmOgrListe fr = new FrmOgrListe();
            fr.Show();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler fr = new FrmOdemeler();
            fr.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGider fr = new FrmGider(); 
            fr.Show();
        }

        private void giderListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderListesi fr = new FrmGiderListesi();
            fr.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirİstatistik fr = new FrmGelirİstatistik();
            fr.Show();
        }

        private void giderİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYoneticiDuzenle fr = new FrmYoneticiDuzenle();
            fr.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel fr = new FrmPersonel();
            fr.Show();
        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotEkle fr =new FrmNotEkle();
            fr.Show();  
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program 14 Nisan 2017 de tamamlanmıştır.", "Öğrenci Yurt Otomasyon",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
