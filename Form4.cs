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
namespace WindowsFormsApplication1
{
    
    public partial class Form4 : Form
    {
       
        SqlConnection baglanti = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\sedat\Desktop\Yeni klasör (2)\Yeni klasör\WindowsFormsApplication1\WindowsFormsApplication1\bin\Debug\halısaha.mdf;Integrated Security=True");

        DataTable tablo = new DataTable();
        SqlCommand komut;
        SqlDataAdapter adp;
        public Form3 frm3;

        public Form4()
        {
            InitializeComponent();
        }
        public void listele()
        {
            baglanti.Open();
            adp = new SqlDataAdapter("Select *From musteribilgianatablo", baglanti);
            tablo = new DataTable();
            adp.Fill(tablo);
            dataGridView1.DataSource = tablo;
            this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            baglanti.Close();
        }
        public void saatlistele()
        {
            try
            {
                baglanti.Open();
                adp = new SqlDataAdapter("Select *From Gun_Saat", baglanti);
                tablo = new DataTable();
                adp.Fill(tablo);
                comboBox1.DataSource = new BindingSource(tablo, null);
                comboBox1.DisplayMember = "Gün_Saat";
                comboBox1.ValueMember = "Id";
                baglanti.Close();
            }
            catch (Exception hataTuru)
            {
                string hata = "Hata meydana geldi." + hataTuru;
            }
        }
        public void sahanolistele()
        {
            try
            {
                baglanti.Open();
                adp = new SqlDataAdapter("Select *From sahalar", baglanti);
                tablo = new DataTable();
                adp.Fill(tablo);
                comboBox2.DataSource = new BindingSource(tablo, null);
                comboBox2.DisplayMember = "saha_no";
                comboBox2.ValueMember = "Id";
                baglanti.Close();
            }
            catch (Exception hataTuru)
            {
                string hata = "Hata meydana geldi." + hataTuru;
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            saatlistele();
            sahanolistele();
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            baglanti.Open();
            string sorgu = "Insert into musteribilgianatablo(ad,soyad,tc,telefon,saha_no_id,tutar,kayıt_tur,gün_saat_id) values(@ad,@soyad,@tc,@telefon,@saha_no_id,@tutar,@kayıt_tur,@gün_saat_id)";
             
            komut = new SqlCommand(sorgu, baglanti);
            if (radioButton1.Checked == true)
            {
                string a = "100";
                textBox6.Text = a;
                komut.Parameters.AddWithValue("@kayıt_tur", radioButton1.Text);
            }

            if (radioButton2.Checked == true)
            {
                string b = "150";
                textBox6.Text = b;
                komut.Parameters.AddWithValue("@kayıt_tur", radioButton2.Text);
            }
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@tc", textBox4.Text);
            komut.Parameters.AddWithValue("@telefon",textBox3.Text);
            komut.Parameters.AddWithValue("@saha_no_id",comboBox2.SelectedValue);
            komut.Parameters.AddWithValue("@gün_saat_id", comboBox1.SelectedValue);
            komut.Parameters.AddWithValue("@tutar", textBox6.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            tablo.Clear();
            MessageBox.Show("Kayıt Girildi");
            this.Close();
            Form4 fr = new Form4();
            fr.Show();
        }

       

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }
 
            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
          
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                

            }
            catch (Exception hataTuru)
            {
                string hata = "Hata meydana geldi." + hataTuru;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM musteribilgianatablo WHERE musteri_id=@musteri_id", baglanti);
            cmd.Parameters.AddWithValue("@musteri_id", dataGridView1.CurrentRow.Cells[0].Value);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
                tablo.Clear();
                listele();
                MessageBox.Show("Kayıt silindi");
                this.Close();
                Form4 fr = new Form4();
                fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE musteribilgianatablo SET ad=@ad,soyad=@soyad,tc=@tc,telefon=@telefon,saha_no_id=@saha_no_id,tutar=@tutar,kayıt_tur=@kayıt_tur,gün_saat_id=@gün_saat_id WHERE musteri_id=@musteri_id ", baglanti);
            if (radioButton1.Checked == true)
            {
                string a = "100";
                textBox6.Text = a;
                komut.Parameters.AddWithValue("@kayıt_tur", radioButton1.Text);
            }

            if (radioButton2.Checked == true)
            {
                string b = "150";
                textBox6.Text = b;
                komut.Parameters.AddWithValue("@kayıt_tur", radioButton2.Text);
            }
            komut.Parameters.AddWithValue("@musteri_id", dataGridView1.CurrentRow.Cells[0].Value);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@tc", textBox4.Text);
            komut.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut.Parameters.AddWithValue("@saha_no_id", comboBox2.SelectedValue);
            komut.Parameters.AddWithValue("@gün_saat_id", comboBox1.SelectedValue);
            komut.Parameters.AddWithValue("@tutar", textBox6.Text);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }


          
            komut.ExecuteNonQuery();
            baglanti.Close();
            tablo.Clear();
            listele();
            MessageBox.Show("Kayıt Güncellendi");
            this.Close();
            Form4 fr = new Form4();
            fr.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {


            try
            {
                baglanti.Open();
               
                
                adp = new SqlDataAdapter("Select *From musteribilgianatablo where  tc like '%" + textBox5.Text + "%' ", baglanti);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                this.dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }
            catch (Exception hataTuru)
            {
                string hata = "Hata meydana geldi." + hataTuru;
            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

      
       

        }

        
    }
}
