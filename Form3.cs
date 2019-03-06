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
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form4 frm4;
        
    
        public Form3()
       
        {
             InitializeComponent();
            frm4= new Form4();
          

            frm4.frm3 = this;
         

    
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
           


        }
      
        
        private void button86_Click(object sender, EventArgs e)
        {
           
        }

        private void button85_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm = new Form4();
            frm.Show();

        }

        private void button87_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }
    }
}
