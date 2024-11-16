using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL Server ile bağlantı kurmak ve veritabanı işlemlerini gerçekleştirmek için gerekli kütüphane.

namespace ÖğrenciNotKayıtSistemi
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        
        
        public string numara;
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FM26IC9\MSSQLSERVER02;Initial Catalog=DbNoteRecordingSystem;Integrated Security=True");

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LblNumara.Text = numara;

            baglanti.Open(); // Sql adresinin olduğu bağlantı açılır.
            SqlCommand komut = new SqlCommand("SELECT * FROM Tbl_Lesson WHERE Student_Number = @p1", baglanti); // Veritabanından öğrenci bilgilerini almak için bir sql komutu yazılır.
            komut.Parameters.AddWithValue("@p1", numara);  // Oluşturduğumuz komuta parametre olarak bir değer eklenir. Parametre olarak alınacak değer ise numara olarak girilen ifadeden alınır.
            SqlDataReader dr = komut.ExecuteReader(); // Oluşturduğumuz komut okunur.
            while (dr.Read()) // Komut satırı okunduğu müddetçe aşağıdaki ifadelere karşılık gelen bilgiler ekrana yazılır.
            {
                LblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString(); // Okunan sql komutunda 2. ve 3. indeksler ad ve soyadlara denk geldiği için birleştirilerek alınır.
                LblSinav1.Text = dr[4].ToString();
                LblSinav2.Text = dr[5].ToString();
                LblSinav3.Text = dr[6].ToString();
                LblOrtalama.Text = dr[7].ToString();
                LblDurum.Text = dr[8].ToString();

                if(dr[8].ToString() == "True")
                {
                    LblDurum.Text = "Geçti";
                }
                else if(dr[8].ToString() == "False") 
                {
                    LblDurum.Text = "Kaldı";
                }
                else
                {
                    LblDurum.Text = " ";
                }

            }
            baglanti.Close(); // Bağlantı kapatılır.
        }
    }
}
