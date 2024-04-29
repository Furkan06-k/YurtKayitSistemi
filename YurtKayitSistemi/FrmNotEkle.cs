using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;//Metin belgesi eklemek için eklediğimiz kütüphane

namespace YurtKayitSistemi
{
    public partial class FrmNotEkle : Form
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {   //Metin Dosyası Kaydetme
            saveFileDialog1.Title = "Kayıt Yeri Seçin";//Nereye kaydedilcek onu seçtik
            saveFileDialog1.Filter = "Metin Dosyası | *.txt";//Hangi türde kaydedilcek diltreledik
            //saveFileDialog1.InitialDirectory ="Klasör yolunu yaz ";//Dosya başlangıçta nerde başlıyacagı yani kaydet dediğimizde ilk o klasörü açacak
            saveFileDialog1.ShowDialog();
            StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);//Yazma işlem, dosya başlı yazma
            kaydet.WriteLine(richTextBox1.Text);
            kaydet.Close();
            MessageBox.Show("Kayıt Yapıldı");
            
        }
    }
}
