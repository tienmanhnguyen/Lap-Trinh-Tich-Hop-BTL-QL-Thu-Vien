using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Clients_ThuVien
{
    public partial class QuanLyBanDoc : Form
    {

        localhost.ServiceQLThuVien proxy = new localhost.ServiceQLThuVien();
        public void LoadData()
        {
            try
            {
                String data = proxy.DanhSachBanDoc();
                DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(data);
                dataGridView.DataSource = dataTable;
               

                textBoxID.Text = "";
                textBoxTen.Text = "";
                textBoxDiaChi.Text = "";
                textBoxSDT.Text = "";
                textBoxTimKiem.Text = "";
                comboBoxGioiTinh.SelectedIndex = 0;
                dateTimePickerNgaySinh.MaxDate = DateTime.Now;
            }catch(Exception e) { }
           
        }


        public QuanLyBanDoc()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int result = 0;
            String HoVaTen = textBoxTen.Text.Trim();
            String SoDienThoai = textBoxSDT.Text.Trim();
            String DiaChi = textBoxDiaChi.Text.Trim();
            bool GioiTinh = false;
            if (comboBoxGioiTinh.SelectedIndex==0) GioiTinh = true;
            DateTime NgaySinh = dateTimePickerNgaySinh.Value;

            if (HoVaTen == null || HoVaTen.Length <= 10 || SoDienThoai == null || SoDienThoai.Length < 10 || textBoxID.Text.Trim() == null || textBoxID.Text.Trim() == "")
            {
                MessageBox.Show("Thông Tin Nhập Không Đủ");
                return;
            }
           
            try
            {
                int Id = Int32.Parse(textBoxID.Text.Trim());
                result = proxy.CapNhatBanDoc(Id, HoVaTen, SoDienThoai,DiaChi, GioiTinh, NgaySinh);
            }
            catch (Exception ex) { }
            if (result == 0)
            {
                MessageBox.Show("Cập Nhật Thất Bại");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thành Công");
                LoadData();
            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            int result = 0;
            String HoVaTen = textBoxTen.Text.Trim();
            String SoDienThoai = textBoxSDT.Text.Trim();
            String DiaChi = textBoxDiaChi.Text.Trim();
            bool GioiTinh = false;
            if (comboBoxGioiTinh.SelectedText.Equals("Nam")) GioiTinh = true;
            DateTime NgaySinh = dateTimePickerNgaySinh.Value;
            if(HoVaTen==null || HoVaTen.Length <= 10 || SoDienThoai == null || SoDienThoai.Length < 10)
            {
                MessageBox.Show("Thông Tin Nhập Không Đủ");
                return;
            }

            try
            {
                result = proxy.ThemBanDoc(HoVaTen, SoDienThoai, DiaChi, GioiTinh, NgaySinh);
            }catch( Exception ex) { }
            if ( result == 0)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            else
            {
                MessageBox.Show("Thêm Thành Công");
                LoadData();
            }


        }

        private void QuanLyBanDoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int result = 0;
           
            DateTime NgaySinh = dateTimePickerNgaySinh.Value;

            if ( textBoxID.Text.Trim() == null || textBoxID.Text.Trim() == "")
            {
                MessageBox.Show("Thông Tin Nhập Không Đủ Hoặc Sai");
                return;
            }
           ;
            try
            {
                int Id = Int32.Parse(textBoxID.Text.Trim());
                result = proxy.XoaBanDoc(Id);
            }
            catch (Exception ex) { }
            if (result == 0)
            {
                MessageBox.Show("Xóa Thất Bại");
            }
            else
            {
                MessageBox.Show("Xóa Thành Công");
                LoadData();
            }
        }

        private void buttonLamTuoi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String ChuoiTimKiem = textBoxTimKiem.Text.Trim();
            if( ChuoiTimKiem == null || ChuoiTimKiem == "")
            {
                MessageBox.Show("Nhập Tên Bạn Đọc Hoặc Số Điện Thoại Vào Ô Tìm Kiếm");
                return;
            }
            try
            {
                String strResult = proxy.TimBanDoc(ChuoiTimKiem);
                DataTable dataSource = JsonConvert.DeserializeObject<DataTable>(strResult);
                LoadData();
                dataGridView.DataSource = dataSource;
            }catch( Exception ex) { }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;
                DataTable dataTable = (DataTable)dataGridView.DataSource;
                var row = dataTable.Rows[rowIndex];
                textBoxID.Text = row.Field<String>("Mã Bạn Đọc");
                textBoxTen.Text = row.Field<String>("Họ Và Tên");
                textBoxSDT.Text = row.Field<String>("Số Điện Thoại");
                textBoxDiaChi.Text = row.Field<String>("Địa Chỉ");
                if (row.Field<String>("Giới Tính") == "Nam") comboBoxGioiTinh.SelectedIndex = 0;
                else comboBoxGioiTinh.SelectedIndex = 1;
                dateTimePickerNgaySinh.Value = DateTime.Parse(row.Field<String>("Ngày Sinh"));
            }catch(Exception ex) { }
           
            
        }
    }
}
