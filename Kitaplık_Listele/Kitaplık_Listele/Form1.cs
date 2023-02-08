using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kitaplık_Listele
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\elifo\Desktop\Kitaplık.accdb
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        KitapVT vtsinif = new KitapVT(); 
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vtsinif.Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kitap ktpsınıf = new Kitap();
            ktpsınıf.Ad = textBox1.Text; //Textboxlardan gelen değerlerin yeni kayıt olarak eklenmesi sağlanır.
            ktpsınıf.Yazar = textBox2.Text;
            vtsinif.KitapEkle(ktpsınıf);
            MessageBox.Show("Kitap Eklendi");
            
        }
    }
}
