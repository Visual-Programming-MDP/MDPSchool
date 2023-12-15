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
            
             if (textNIS.Text == "" || textNama.Text == "" || jk == "" || textTempat.Text == "" || textAlamat.Text == "" || textAsalSekolah.Text == "" || cbAgama.Text == "" || textHp.Text == "") //|| textLokasiFoto.Text == ""
            {
                 MessageBox.Show("Data Harus Diisi", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
             else
             {
                 //Data disimpan
                 koneksi.tutupDatabase();
                 koneksi.bukaDatabase();
                 koneksi.perintahSQL.CommandText = "INSERT INTO Siswa VALUES (@nis, @nama, @jk, @tempat, @tgllahir, @alamat, @asalsekolah, @agama, @nohp, @alamatfoto)";

                 koneksi.perintahSQL.Parameters.AddWithValue("@nis", textNIS.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@nama", textNama.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@jk", jk);
                 koneksi.perintahSQL.Parameters.AddWithValue("@tempat", textTempat.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@tgllahir", dtpTanggal.Value);
                 koneksi.perintahSQL.Parameters.AddWithValue("@alamat", textAlamat.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@asalsekolah", textAsalSekolah.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@agama", cbAgama.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@nohp", textHp.Text);
                 koneksi.perintahSQL.Parameters.AddWithValue("@alamatfoto", textLokasiFoto.Text);

                 koneksi.perintahSQL.ExecuteNonQuery();

                 MessageBox.Show("Data Berhasil Disimpan", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 koneksi.tutupDatabase();

                 tampil();
                 bersih();
             }
        }

        private void textTanggalLahir_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //jika ada data pada DataGridView
                textNIS.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textNama.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                jk = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (jk.Equals("L"))
                {
                    radioLakilaki.Checked = true;
                }
                else
                {
                    radioPerempuan.Checked = true;
                }

                textTempat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpTanggal.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                textAlamat.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textAsalSekolah.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                cbAgama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textHp.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textLokasiFoto.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                pictureBox1.Image = Image.FromFile(textLokasiFoto.Text);
                btnSimpan.Enabled = false;
            }
        }
        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (textNIS.Text == "" || textNama.Text == "" || jk == "" || textTempat.Text == "" || textAlamat.Text == "" || textAsalSekolah.Text == "" || cbAgama.Text == "" || textHp.Text == "") //|| textLokasiFoto.Text == ""
            {
                MessageBox.Show("Data Harus Diisi", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //Data diubah
                koneksi.tutupDatabase();
                koneksi.bukaDatabase();
                koneksi.perintahSQL.CommandText = "UPDATE Siswa SET nama = @nama, jeniskelamin = @jk, tempat = @tempat, tanggallahir = @tgllahir, alamat = @alamat, asalsekolah = @asalsekolah, agama = @agama, nohp = @nohp, alamatfoto = @alamatfoto WHERE nis = @nis";

                koneksi.perintahSQL.Parameters.AddWithValue("@nis", textNIS.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@nama", textNama.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@jk", jk);
                koneksi.perintahSQL.Parameters.AddWithValue("@tempat", textTempat.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@tgllahir", dtpTanggal.Value);
                koneksi.perintahSQL.Parameters.AddWithValue("@alamat", textAlamat.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@asalsekolah", textAsalSekolah.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@agama", cbAgama.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@nohp", textHp.Text);
                koneksi.perintahSQL.Parameters.AddWithValue("@alamatfoto", textLokasiFoto.Text);

                koneksi.perintahSQL.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil Diubah", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                koneksi.tutupDatabase();

                tampil();
                bersih();
            }
        }
        
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (textNIS.Text == "" || textNama.Text == "" || jk == "" || textTempat.Text == "" || textAlamat.Text == "" || textAsalSekolah.Text == "" || cbAgama.Text == "" || textHp.Text == "") //|| textLokasiFoto.Text == ""
            {
                MessageBox.Show("Data Harus Diisi", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            else
            {//Data dihapus
                koneksi.tutupDatabase();
                koneksi.bukaDatabase();
                koneksi.perintahSQL.CommandText = "DELETE FROM Siswa WHERE nis = @nis";

                koneksi.perintahSQL.Parameters.AddWithValue("@nis", txtNis.Text);

                koneksi.perintahSQL.ExecuteNonQuery();

                MessageBox.Show("Data Berhasil Dihapus", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                koneksi.tutupDatabase();

                tampil();
                bersih();
            }
        }

        private void btnBersih_Click(object sender, EventArgs e)
        {
            bersih();
            tampil();
        }

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
