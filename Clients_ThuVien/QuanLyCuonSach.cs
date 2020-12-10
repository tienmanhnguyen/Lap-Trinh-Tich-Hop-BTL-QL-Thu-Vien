using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Clients_ThuVien
{
    public partial class QuanLyCuonSach : Form
    {

        localhost.ServiceQLThuVien proxy = new localhost.ServiceQLThuVien();
        public QuanLyCuonSach()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                String result = proxy.DanhSachCuonSach();
                DataTable table = JsonConvert.DeserializeObject<DataTable>(result);
                dataGridView.DataSource = table;
                dataGridView.AutoResizeColumns();

                textBoxID.Text = "";
                textBoxSoDanhNhan.Text = "";
                textBoxISBN.Text = "";
                textBoxTenSach.Text = "";
                textBoxTimKiem.Text = "";
                numericUpDownNamXB.Value = 0;
                comboBoxNhaXuatBan.Text = "";
                comboBoxNN.Text = "";

            }catch( Exception e)
            {
                MessageBox.Show("Lỗi Load Data");
            }
           
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyCuonSach_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            int result = 0;
            String ISBN = textBoxISBN.Text.Trim();
            String SoDanhNhan = textBoxSoDanhNhan.Text.Trim();

            if (ISBN == null || ISBN.Length <= 10 || SoDanhNhan == null || SoDanhNhan.Length < 5)
            {
                MessageBox.Show("Thông Tin Nhập Không Đủ");
                return;
            }

            try
            {
                result = proxy.ThemCuonSach(ISBN, SoDanhNhan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm Thất Bại! Lỗi Đầu vào");
            }
            if (result == 0)
            {
                MessageBox.Show("Thêm Thất Bại");
            }
            else
            {
                MessageBox.Show("Thêm Thành Công");
                LoadData();
            }
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String ChuoiTimKiem = textBoxTimKiem.Text.Trim();
            if (ChuoiTimKiem == null || ChuoiTimKiem == "")
            {
                MessageBox.Show("Nhập Số Đánh Nhãn hoặc ISBN Hoặc Tên Sách Vào Ô Tìm Kiếm");
                return;
            }
            try
            {
                String strResult = proxy.TimCuonSach(ChuoiTimKiem);
                DataTable dataSource = JsonConvert.DeserializeObject<DataTable>(strResult);
                LoadData();
                dataGridView.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (textBoxID.Text.Trim() == null || textBoxID.Text.Trim() == "")
            {
                MessageBox.Show("Thông Tin Nhập Không Đủ Hoặc Sai");
                return;
            }
            try
            {
                int Id = Int32.Parse(textBoxID.Text.Trim());
                result = proxy.XoaCuonSach(Id);
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

        private void textBoxISBN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String ISBN = textBoxISBN.Text.Trim();
                String result = proxy.TimDauSach(ISBN);
                DataTable table = (DataTable)JsonConvert.DeserializeObject<DataTable>(result);
                textBoxTenSach.Text = table.Rows[0].Field<String>("Tên Đầu Sách");
                comboBoxNhaXuatBan.Text = table.Rows[0].Field<String>("Nhà Xuất Bản");
                comboBoxNN.Text = table.Rows[0].Field<String>("Ngôn Ngữ");
                numericUpDownNamXB.Value = int.Parse(table.Rows[0].Field<String>("Năm Xuất Bản"));
            }catch( Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int rowIndex = dataGridView.CurrentCell.RowIndex;
                DataTable dataTable = (DataTable)dataGridView.DataSource;
                var row = dataTable.Rows[rowIndex];
                textBoxID.Text = row.Field<String>("Mã Cuốn Sách");
                textBoxISBN.Text = row.Field<String>("ISBN");
                textBoxTenSach.Text = row.Field<String>("Tên Đầu Sách");
                comboBoxNhaXuatBan.Text = row.Field<String>("Nhà Xuất Bản");
                comboBoxNN.Text = row.Field<String>("Ngôn ngữ");
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
