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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLKTRA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string chuoiketnoi = @"Data Source=HGIA;Initial Catalog=SinhVien;Integrated Security=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadKhoa();
            loadPhong();
            loadSV();
        }
        private void loadKhoa()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = " Select* From Khoa ";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void loadSV()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from SV ";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }
        private void loadPhong()
        {
            ketnoi = new SqlConnection(chuoiketnoi);

            ketnoi.Open();
            sql = "select* from Phong  ";
            hienthi();
            dataGridView3.DataSource = dt;
            ketnoi.Close();
        }
        public void hienthi()
        {
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);

        }
        public void xoa()
        {
            txtmasv.Clear();
            txttensv.Clear();
            txtnamsinh.Clear();
            txtgioitinh.Clear();
            txtdiachi.Clear();
            txtdienthoai.Clear();
         
        }
        String masv;
        //string makhoa;

        private void xoasv_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete SV where masosv ='" + masv + "'";

            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from SV";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
            loadSV();
        }

        private void suasv_Click(object sender, EventArgs e)
        {
            string masv = txtmasv.Text;
            string hoVaTen = txttensv.Text;
            string namSinh = txtnamsinh.Text;
            string gioiTinh = txtgioitinh.Text;
            string dienThoai = txtdienthoai.Text;
            string diaChi = txtdiachi.Text;

            // check gia tri nguời dùng nhập có đúng không - ví dụ là nhập chưa đủ thông tin:

     
            ketnoi.Open();
            sql = @"update SV
	        SET
            masosv =N'" + masv + "' ,hoten=  N'" + hoVaTen + "' ,namsinh= N'" + namSinh + "'  ,gioitinh= N'" + gioiTinh + "'  ,dienthoai=N'" + dienThoai + "' , diachi= N'" + diaChi + "' where masosv='" + masv + "'";
            MessageBox.Show("Đã sửa thành công !!!");
       
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from SV";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
            loadSV();
        }

        private void themsv_Click(object sender, EventArgs e)
        {
            string masv = txtmasv.Text;
            string hoVaTen = txttensv.Text;
            string namSinh = txtnamsinh.Text;
            string gioiTinh = txtgioitinh.Text;
            string dienThoai = txtdienthoai.Text;
            string diaChi = txtdiachi.Text;
            ketnoi.Open();
            sql = @"insert into SV
	        values
            (N'" + masv + "', N'" + hoVaTen + "', N'" + namSinh + "', N'" + gioiTinh + "',N'" + dienThoai + "',N'" + diaChi + "')";
            MessageBox.Show("THÊM THÀNH CÔNG!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select* from SV";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
            loadSV() ;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            masv = row.Cells[0].Value.ToString();
        }
    }
}
