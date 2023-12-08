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
    public partial class FormMenuUtama : Form
    {
        string username = FormLogin.username;
        string level = FormLogin.level;

        public FormMenuUtama()
        {
            InitializeComponent();

            if (username == null && level == null)
            {
                nonaktifmenu();
            }
            else
            {
                aktifmenu();
            }
        }

        
        //Menu Logout
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah Anda Ingin Keluar Aplikasi ? ", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Application.Exit(); //menutup aplikasi scr kesuluruhan
                this.Close();       //menutup form yang sedang terbuka

                //Munculkan Form Login
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
            }
        }
        //Menu Data Siswa
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FormSiswa formSiswa = new FormSiswa();
            formSiswa.MdiParent = this;
            formSiswa.Show();
        }

        //Menu Tampil Data
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FormTampilSiswa formTampilSiswa = new FormTampilSiswa();
            formTampilSiswa.MdiParent = this;
            formTampilSiswa.Show();
        }

        public void nonaktifmenu()
        {
            menuTampilData.Enabled = false;
            menuDataSiswa.Enabled = false;
            menuLaporan.Enabled = false;
        }

        private void aktifmenu()
        {
            //Hak akses : admin, dan siswa
            if (level.Equals("admin"))
            {
                menuTampilData.Enabled = true;
                menuDataSiswa.Enabled = true;
                menuLaporan.Enabled = true;
            }
            else
            {
                menuTampilData.Enabled = true;
                menuDataSiswa.Enabled = false;
                menuLaporan.Enabled = false;
            }

            lblUsername.Text = username.ToString();
            lblLevel.Text = level.ToString();
        }
    }
}
