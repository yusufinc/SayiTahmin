using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayıTahmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int sayi = 0, tahmin_sayisi = 0, puan = 1000;
        private void Form1_Load(object sender, EventArgs e)
        {
            //başlangıçta textbox kapalı olsun. button 2 eventinde açılsın.
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //textBoxa harf yazdırmayı engelle
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tahmin;
            tahmin_sayisi++;
            if (tahmin_sayisi<=10)
            {
                tahmin = int.Parse(textBox1.Text);
                label6.Text=tahmin_sayisi.ToString();
                if (sayi<tahmin)
                {
                    label5.Text = " Tahmininizi Azaltın!!";
                    puan = puan - 100;
                    label7.Text=puan.ToString();
                }
                else if (tahmin<sayi)
                {
                    label5.Text = " Tahmininizi Artırın!!";
                    puan = puan - 100;
                    label7.Text = puan.ToString();
                }
                else
                {
                    label5.Text = "Bravo 👌👏 " + label6.Text + ". defada bilip " + label7.Text + " Puan kazandınız";
                    button2.Enabled = true;
                    button1.Enabled = false;
                }
                textBox1.Text = "";
                
            }
            else
            {
                textBox1.Enabled = false;
                MessageBox.Show("Tahmin Hakkınız Kalmadı Oyun Kapatılacak");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = false;
            Random r=new Random();
            sayi = r.Next(1, 100);
            label8.Text= sayi.ToString();
            label5.Text = " ";
            label6.Text = "0";
            label7.Text = "1000";
        }
    }
}
