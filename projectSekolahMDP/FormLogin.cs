using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectSekolahMDP
{
    public partial class FormLogin : Form
    {
        public static String username = "";
        public static String level = "";
        public FormLogin()
        {
            InitializeComponent();
            bersih();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void bersih()
        {
            txtUsername.Clear(); //untuk membersihkan   
            txtPassword.Clear();
            txtUsername.Focus(); //agar kursor fokus ke teksbox
        }

        //Tombol Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Set variabel username dan level
            username = "Mimin";
            level = "admin";

            FormMenuUtama menuUtama = new FormMenuUtama();
            menuUtama.Show(); //tampilkan menu utama

            this.Hide();    //menyembunyikan form
        }
    }
}
