using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text.Trim() == ayar.Default.kullaniciadi.ToString() && textBox2.Text.Trim() == ayar.Default.sifre.ToString())
                {
                    this.Hide();
                    Form2 frm = new Form2();
                    frm.Show();
                }
                else if (textBox1.Text == "" && textBox2.Text == "")
                {
                    MessageBox.Show("Boş bırakmayınız.");
                }
                else
                {
                    
                    MessageBox.Show("hatalı kullnaıcı adı veya şifre");

                }
               
            }
            catch (Exception hataTuru)
            {
                string hata = "Hata meydana geldi." + hataTuru;
            }
                

          

        }

    }

}

