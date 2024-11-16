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

namespace ÖğrenciNotKayıtSistemi
{
    public partial class FrmOgretmenDetay : Form
    {
        public FrmOgretmenDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-FM26IC9\MSSQLSERVER02;Initial Catalog=DbNoteRecordingSystem;Integrated Security=True");
        private void FrmOgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbNoteRecordingSystemDataSet.Tbl_Lesson' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_LessonTableAdapter.Fill(this.dbNoteRecordingSystemDataSet.Tbl_Lesson);
            object ort;
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("SELECT AVG(Average) FROM Tbl_Lesson WHERE Average IS NOT NULL", baglanti);
            ort = komut1.ExecuteScalar();
            LblGenelOrtalama.Text = Convert.ToDouble(ort).ToString("F2");

            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Lesson WHERE Situation = 0", baglanti);
            object kalan = komut2.ExecuteScalar();
            LblKalanSayisi.Text = kalan.ToString();

            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Lesson WHERE Situation = 1", baglanti);
            object gecen = komut3.ExecuteScalar();
            LblGecenSayisi.Text = gecen.ToString();

            baglanti.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Lesson (Student_Number, Student_Name, Student_Surname) VALUES (@P1, @P2, @P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", MskNumara.Text);
            komut.Parameters.AddWithValue("@P2", TxtAd.Text);
            komut.Parameters.AddWithValue("@P3", TxtSoyad.Text);
            komut.ExecuteNonQuery(); // INSERT, UPDATE, DELETE gibi veri manipülasyon komutlarını (dml) çalıştırmak veya sadece prosedürler yürütmek için kullanılır. Sonuç döndürmeyen işlemler için uygundur. 
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi.");
            this.tbl_LessonTableAdapter.Fill(this.dbNoteRecordingSystemDataSet.Tbl_Lesson); // Otomatik doldurma komutudur. Yeni bir öğrenci eklendiğinde güncel liste ekrana yazdırılır.
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // Not listesinden seçilen bilgilerin ekrana yazılması için kullanılır.
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;  // Not listesinden seçilen satır bilgileri bir değişkene atanır.
            MskNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtSinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();  // Not listesinde seçilen satırdaki 4.hücrenin değeri alınır.
            TxtSinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtSinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            LblOrtalama.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSinav1.Text);
            s2 = Convert.ToDouble(TxtSinav2.Text);
            s3 = Convert.ToDouble(TxtSinav3.Text);

            ortalama = (s1 + s2 + s3) / 3;
            LblOrtalama.Text = ortalama.ToString("F2");  // F harfi, "fixed-point" (sabit noktalı) formatı, 2 ise ondalık basamak sayısını ifade eder.

            if(ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Tbl_lesson SET Student_Exam1 = @P1, Student_Exam2 = @P2, Student_Exam3 = @P3, Average = @P4, Situation = @P5 WHERE Student_Number = @P6", baglanti);
            komut.Parameters.AddWithValue("@P1", TxtSinav1.Text);
            komut.Parameters.AddWithValue("@P2", TxtSinav2.Text);
            komut.Parameters.AddWithValue("@P3", TxtSinav3.Text);
            komut.Parameters.AddWithValue("@P4", decimal.Parse(LblOrtalama.Text));
            komut.Parameters.AddWithValue("@P5", durum);
            komut.Parameters.AddWithValue("@P6", MskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi.");
            this.tbl_LessonTableAdapter.Fill(this.dbNoteRecordingSystemDataSet.Tbl_Lesson);
        }
    }
}
