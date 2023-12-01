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
        public static string username = "";
        public static string level = "";

        ClassKoneksi koneksi = new ClassKoneksi();

        public FormLogin()
        {
            InitializeComponent();
            bersih();
        }

        //Tombol Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Username / Password Harus Diisi", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bersih();
            }
            else
            {
                koneksi.bukaDatabase();

                //perintah sql untuk menampilkan data pada tabel Users berdasarkan username dan password yang diinputkan
                koneksi.perintahSQL.CommandText = "SELECT * FROM Users WHERE username = @user AND password = @pass";

                koneksi.perintahSQL.Parameters.AddWithValue("@user", txtUsername.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@pass", txtPassword.Text);

                koneksi.cari = koneksi.perintahSQL.ExecuteReader();

                if (koneksi.cari.Read() == true)
                {
                    //jika data ada pada tabel Users di database, maka tampilkan pesan Selamat <<username>> Anda Berhasil Login sebagai <<level>>
                    username = koneksi.cari["username"].ToString();
                    level = koneksi.cari["level"].ToString();

                    MessageBox.Show("Selamat " + username + ", Anda Berhasil Login \nSebagai " + level, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    FormMenuUtama menuUtama = new FormMenuUtama();
                    menuUtama.Show();
                }
                else
                {
                    //jika data tidak ada pada tabel Users maka akan menampilkan pesan Username / Password salah
                    MessageBox.Show("Username / Password Salah", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bersih();
                }

                koneksi.tutupDatabase();
            }
        }



        public void bersih()
        {
            txtUsername.Clear(); //untuk membersihkan   
            txtPassword.Clear();
            txtUsername.Focus(); //agar kursor fokus ke teksbox
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
