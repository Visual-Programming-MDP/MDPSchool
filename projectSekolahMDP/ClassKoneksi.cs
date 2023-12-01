using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectSekolahMDP
{
    class ClassKoneksi
    {
        //Koneksi SQL Server
        public SqlConnection koneksi = new SqlConnection();

        //perintah SQL
        public SqlCommand perintahSQL = new SqlCommand();

        //Data Adapter = mengisi data ke datagridview
        public SqlDataAdapter da = new SqlDataAdapter();

        //Data Set = Tabel
        public DataSet ds = new DataSet();

        //Data Reader = pencarian data ke tabel
        public SqlDataReader cari;

        public void bukaDatabase()
        {
            try
            {
                //Jika DataBase Berhasil Diakses
                koneksi.ConnectionString = "Data Source=.;Initial Catalog=dbMDPSchool;Integrated Security=True";
                koneksi.Open();
                perintahSQL.Connection = koneksi;
            }
            catch
            {
                //Jika Database Tidak Berhasil Diakses
                MessageBox.Show("Koneksi Database Gagal", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void tutupDatabase()
        {
            koneksi.Close();
        }

    }
}
