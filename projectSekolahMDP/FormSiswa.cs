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
    public partial class FormSiswa : Form
    {
        ClassKoneksi koneksi = new ClassKoneksi();
        public string jk;
        public FormSiswa()
        {
            InitializeComponent();
            tampil();

            //agama
            cbAgama.Items.Add("Islam");
            cbAgama.Items.Add("Katolik");
            cbAgama.Items.Add("Kristen");
            cbAgama.Items.Add("Buddha");
            cbAgama.Items.Add("Khonghucu");
            cbAgama.Items.Add("Hindu");
        }


        //Untuk menampilkan data ke DataGridView
        public void tampil()
        {
            koneksi.tutupDatabase();
            koneksi.ds.Clear();

            koneksi.bukaDatabase();
            koneksi.perintahSQL.CommandText = "SELECT * FROM Siswa";
            koneksi.da.SelectCommand = koneksi.perintahSQL;
            koneksi.da.Fill(koneksi.ds, "Siswa");

            dataGridView1.DataSource = koneksi.ds;
            dataGridView1.DataMember = "Siswa";

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //bersih layar
        public void bersih()
        {
            textNIS.Clear();
            textNama.Clear();
            radioLakilaki.Checked = false;
            radioPerempuan.Checked = false;
            textTempat.Clear();
            textTanggalLahir.Clear();
            textAlamat.Clear();
            textAsalSekolah.Clear();
            cbAgama.Text = "";
            textHp.Clear();
            textLokasiFoto.Clear();
            pictureBox1.Image = null;
            btnSimpan.Enabled = true;
        }


        private void btnUbahFoto_Click(object sender, EventArgs e)
        {
            //Mencari Gambar yang akan disimpan
            OpenFileDialog cariGambar = new OpenFileDialog();
            cariGambar.InitialDirectory = @"D:\VISUAL\";
            cariGambar.Filter = "IMAGE FILE | *.jpg; *.jpeg";
            cariGambar.Title = "CARI GAMBAR";

            if (cariGambar.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(cariGambar.FileName);

                //Lokasi Gambar
                textLokasiFoto.Text = cariGambar.FileName;

                Image img = new Bitmap(cariGambar.FileName);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void radioLakilaki_CheckedChanged(object sender, EventArgs e)
        {
            jk = "L";
        }

        private void radioPerempuan_CheckedChanged(object sender, EventArgs e)
        {
            jk = "P";
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            /*
             * 
             * 
             if (txtNis.Text == "" || txtNama.Text == "" || jk == "" || txtTempat.Text == "" || txtAlamat.Text == "" || txtAsalSekolah.Text == "" || cmbAgama.Text == "" || txtNoHp.Text == "" || txtLokasiFoto.Text == "")
             {
                 MessageBox.Show("Data Harus Diisi", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 //Data disimpan
                 koneksi.tutupDatabase();
                 koneksi.bukaDatabase();
                 koneksi.perintahSQL.CommandText = "INSERT INTO Siswa VALUES (@nis, @nama, @jk, @tempat, @tgllahir, @alamat, @asalsekolah, @agama, @nohp, @alamatfoto)";

                 koneksi.perintahSQL.Parameters.AddWithValue("@nis", txtNis.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@nama", txtNama.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@jk", jk);
                 koneksi.perintahSQL.Parameters.AddWithValue("@tempat", txtTempat.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@tgllahir", dtpTanggalLahir.Value);
                 koneksi.perintahSQL.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@asalsekolah", txtAsalSekolah.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@agama", cmbAgama.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@nohp", txtNoHp.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@alamatfoto", txtLokasiFoto.Text);

                 koneksi.perintahSQL.ExecuteNonQuery();

                 MessageBox.Show("Data Berhasil Disimpan", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 koneksi.tutupDatabase();

                 tampil();
                 bersih();
             }

             */
        }

        /*
         * 
         * 
          private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //jika ada data pada DataGridView
                txtNis.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtNama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                jk = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (jk.Equals("L"))
                {
                    rdLakiLaki.Checked = true;
                }
                else
                {
                    rdPerempuan.Checked = true;
                }

                txtTempat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpTanggalLahir.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtAlamat.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtAsalSekolah.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                cmbAgama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtNoHp.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtLokasiFoto.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                pictureBox1.Image = Image.FromFile(txtLokasiFoto.Text);
                btnSimpan.Enabled = false;
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (txtNis.Text == "" || txtNama.Text == "" || jk == "" || txtTempat.Text == "" || txtAlamat.Text == "" || txtAsalSekolah.Text == "" || cmbAgama.Text == "" || txtNoHp.Text == "" || txtLokasiFoto.Text == "")
            {
                MessageBox.Show("Data Harus Diisi", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Data diubah
                koneksi.tutupDatabase();
                koneksi.bukaDatabase();
                koneksi.perintahSQL.CommandText = "";

                koneksi.perintahSQL.Parameters.AddWithValue("@nis", txtNis.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@nama", txtNama.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@jk", jk);
                koneksi.perintahSQL.Parameters.AddWithValue("@tempat", txtTempat.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@tgllahir", dtpTanggalLahir.Value);
                koneksi.perintahSQL.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@asalsekolah", txtAsalSekolah.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@agama", cmbAgama.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@nohp", txtNoHp.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@alamatfoto", txtLokasiFoto.Text);

                koneksi.perintahSQL.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil Diubah", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                koneksi.tutupDatabase();

                tampil();
                bersih();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (txtNis.Text == "" || txtNama.Text == "" || jk == "" || txtTempat.Text == "" || txtAlamat.Text == "" || txtAsalSekolah.Text == "" || cmbAgama.Text == "" || txtNoHp.Text == "" || txtLokasiFoto.Text == "")
            {
                MessageBox.Show("Data Harus Diisi", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Data disimpan
                koneksi.tutupDatabase();
                koneksi.bukaDatabase();
                koneksi.perintahSQL.CommandText = "INSERT INTO Siswa VALUES (@nis, @nama, @jk, @tempat, @tgllahir, @alamat, @asalsekolah, @agama, @nohp, @alamatfoto)";

                koneksi.perintahSQL.Parameters.AddWithValue("@nis", txtNis.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@nama", txtNama.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@jk", jk);
                koneksi.perintahSQL.Parameters.AddWithValue("@tempat", txtTempat.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@tgllahir", dtpTanggalLahir.Value);
                koneksi.perintahSQL.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@asalsekolah", txtAsalSekolah.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@agama", cmbAgama.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@nohp", txtNoHp.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@alamatfoto", txtLokasiFoto.Text);

                koneksi.perintahSQL.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil Dihapus", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                koneksi.tutupDatabase();

                tampil();
                bersih();
            }
        }
         * 
         * */
    }
}
