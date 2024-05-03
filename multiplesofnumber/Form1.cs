using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multiplesofnumber
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Verilerin gösterileceği richTextBox'ı yazmaya kapatıyoruz.
            rtxtValue.ReadOnly = true;
            cmbKat.Items.Add("2"); //ComboBox'a item ekliyoruz: integer türünde, kat olacak sayılar giriyoruz. 
            cmbKat.Items.Add("3");
            cmbKat.Items.Add("4");
            cmbKat.Items.Add("5");
            cmbKat.Items.Add("6");
            cmbKat.Items.Add("7");
            cmbKat.Items.Add("8");
            cmbKat.Items.Add("9");
            cmbKat.Items.Add("10");
        }

        private void txtSayi1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //sadece sayı girilsin.
        }

        private void txtSayi2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //sadece sayı girilsin.
        }
        int sayi1, sayi2, kat;

        private void rdBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBlack.Checked) rtxtValue.ForeColor = Color.Black; //Siyah
        }

        private void rdGreen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGreen.Checked) rtxtValue.ForeColor = Color.Green; //Yeşil
        }

        private void btnGoster_Click(object sender, EventArgs e)
        {
            if (txtSayi1.Text.Trim() == "") //textbox içinin boş olup olmadığını kontrol eder. Eğer hiçbir karakter yoksa veya yalnızca boşluk varsa... 
            {
                errorProvider1.SetError(txtSayi1, "Alanı Doldurun!"); //error provider'ın ilgili textbox da kullanımı.
                MessageBox.Show("Lütfen sayıları giriniz!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtSayi2.Text.Trim() == "")
            {
                errorProvider1.SetError(txtSayi2, "Alanı Doldurun!");
                MessageBox.Show("Lütfen sayıları giriniz!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbKat.SelectedIndex == -1) // comboboxlarda seçim yapılmadıysa index değerleri -1 olur. Seöim yapılmadığında uyarı vermesi için bu kodları yazıyoruz.
            {
                errorProvider1.SetError(cmbKat, "Kat Sayısı Seçin!");
                MessageBox.Show("Lütfen sayılar arasında hesaplanacak kat sayısını seçiniz!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else //Yukarıdaki if'ler textboxların ve comboboxların dolu olup olmadığını kontrol eden bloklardı. Eğer hepsi doluysa hiç bir if çalışmaz ve else durumu çalışır.
            {
                rtxtValue.Clear(); // Her butona basılışta richtextbox'da gösterilen verileri 0'la yıp aşağıdaki kod bloklarını çalıştırması için yazdım. Bilgiler üst üste binmeyecek.

                sayi1 = Convert.ToInt32(txtSayi1.Text);     //Bu kısım tanımlı değişkenlere verileri aktarma kısmı.
                sayi2 = Convert.ToInt32(txtSayi2.Text);
                kat = Convert.ToInt32(cmbKat.SelectedItem); //Combobox içindeki veriler de stringten geliyor seçili veriyi int çevirip kat değişkenine aktarıyoruz.

                if (sayi1 < sayi2) //Bu if bloklarının amacı kullanıcı sayıyı girerken hangi sayının büyük veya küçükse ona göre artarak veya azalarak sonuç göstermesini sağlamak. Eşit değerler ise programı da çalıştırmaz.
                {
                    for (; sayi1 <= sayi2; sayi1++) //döngü şartı küçük sayı <= büyük sayı olduğu sürece küçüğü 1 arttır. 
                    {
                        if (sayi1 % kat == 0) rtxtValue.Text += " " + sayi1 + " "; //Küçük sayı artarken combobox'tan gelen kat değeri ile tam bölündüğünde richtext'e sayi1'i ekle. " " : Boşluk kalması için.
                    }
                    MessageBox.Show(txtSayi1.Text + " ile " + txtSayi2.Text + " sayıları arasında olan " + cmbKat.SelectedItem + " ve katları hesaplandı.", "İşlem Tamamlandı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } //richtexbox'a ilk textbox'daki sayının artarak giden katlarını göstericek. Çünkü küçük sayı.


                else if (sayi1 > sayi2) //Bu durumda ilk girilen textbox 2. girilen textbox'tan büyük ise olan durum. Böylece en önemlisi programın çalışmama durumunu engellemiş olduk.
                {

                    for (; sayi2 <= sayi1; sayi1--) //döngü şartı küçük sayı <= büyük sayı olduğu sürece büyüğü 1 eksilt.
                    {
                        if (sayi1 % kat == 0) rtxtValue.Text += " " + sayi1 + " "; //büyük sayı azalırken combobox'tan gelen kat değeri ile tam bölündüğünde richtext'e sayi1'i ekle. " " : Boşluk kalması için.
                    }
                    MessageBox.Show(txtSayi1.Text + " ile " + txtSayi2.Text + " sayıları arasında olan " + cmbKat.SelectedItem + " ve katları hesaplandı.", "İşlem Tamamlandı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }//richtexbox'a ilk textbox'daki sayının azalarak giden katlarını göstericek. Çünkü büyük sayı.


                else MessageBox.Show("Sayılar Aynı Girilemez!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Error);// Eğer iki sayıda birbirine eşitse bu uyarıyı verir.



            }
        }

        private void rdBlue_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBlue.Checked) rtxtValue.ForeColor = Color.Blue; //Mavi
        }

        private void rdRed_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRed.Checked) rtxtValue.ForeColor = Color.Red; //Kırmızı yazan buton seçilirse. RichTextbox içindeki verilerin rengini kırmızı yap.
        }
    }
}
