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
using System.Collections;
namespace Clients_ThuVien
{
    public partial class QuanLyDauSach : Form
    {
        localhost.ServiceQLThuVien proxy = new localhost.ServiceQLThuVien();
        public QuanLyDauSach()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                String dataNXB = proxy.danhSachNhaXuatBan();
                ArrayList nxb = JsonConvert.DeserializeObject<ArrayList>(dataNXB);
                String result = proxy.DanhSachDauSach();
                DataTable table = JsonConvert.DeserializeObject<DataTable>(result);
                dataGridView.DataSource = table;
                dataGridView.AutoResizeColumns();


                textBoxID.Text = "";
                textBoxISBN.Text = "";
                textBoxTenSach.Text = "";
                textBoxTrongLuong.Text = "";
                textBoxTimKiem.Text = "";
                textBoxKichThuoc.Text = "";
                textBoxGiaBia.Text = "";
                numericUpDownNamXB.Value = 2020;
                numericUpDownNgayMuon.Value = 0;
                numericUpDownSoTrang.Value = 0;
                comboBoxNhaXuatBan.Items.Clear();
                for (int i = 0; i < nxb.Count; i++)
                {
                    comboBoxNhaXuatBan.Items.Add(nxb[i]);
                }
                comboBoxNhaXuatBan.SelectedIndex = 0;

                comboBoxNN.Items.Clear();
                comboBoxNN.Items.Add("Tiếng Việt");
                comboBoxNN.Items.Add("Tiếng Anh");
                comboBoxNN.Items.Add("Khác");
                comboBoxNN.SelectedIndex = 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            int result = 0;
            String ISBN = textBoxISBN.Text.Trim();
            String TenSach = textBoxTenSach.Text.Trim();
            String GiaBia = textBoxGiaBia.Text.Trim();
            String TrongLuong = textBoxTrongLuong.Text.Trim();
            String KichThuoc = textBoxKichThuoc.Text.Trim();
            int SoTrang = (int)numericUpDownSoTrang.Value;
            int NgayToiDaMuon = (int)numericUpDownNgayMuon.Value;
            String namXb = numericUpDownNamXB.Value.ToString();
            String NhaXuatBan = comboBoxNhaXuatBan.SelectedItem.ToString();
            String NgoaiNgu = comboBoxNN.SelectedItem.ToString();
            if (ISBN == null || ISBN.Length <= 10 || TenSach == null || TenSach.Length < 10)
            {
                MessageBox.Show("Thông Tin Nhập Không Đủ");
                return;
            }

            try
            {
                double giaBia = Double.Parse(GiaBia);
                int trongLuong = Int32.Parse(TrongLuong);
                result = proxy.ThemDauSach(ISBN, TenSach, namXb, KichThuoc, NgoaiNgu, trongLuong, giaBia, SoTrang, NgayToiDaMuon, NhaXuatBan);
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

        private void buttonSua_Click(object sender, EventArgs e)
        {
            int result = 0;
            String ID = textBoxID.Text.Trim();
            String ISBN = textBoxISBN.Text.Trim();
            String TenSach = textBoxTenSach.Text.Trim();
            String GiaBia = textBoxGiaBia.Text.Trim();
            String TrongLuong = textBoxTrongLuong.Text.Trim();
            String KichThuoc = textBoxKichThuoc.Text.Trim();
            int SoTrang = (int)numericUpDownSoTrang.Value;
            int NgayToiDaMuon = (int)numericUpDownNgayMuon.Value;
            String namXb = numericUpDownNamXB.Value.ToString();
            String NhaXuatBan = comboBoxNhaXuatBan.SelectedItem.ToString();
            String NgoaiNgu = comboBoxNN.SelectedItem.ToString();
            if (ISBN == null || ISBN.Length <= 10 || TenSach == null || TenSach.Length < 10)
            {
                MessageBox.Show("Thông Tin Nhập Không Đủ");
                return;
            }

            try
            {
                int id = Int32.Parse(ID);
                double giaBia = Double.Parse(GiaBia);
                int trongLuong = Int32.Parse(TrongLuong);
                result = proxy.CapNhatDauSach(id, ISBN, TenSach, namXb, KichThuoc, NgoaiNgu, trongLuong, giaBia, SoTrang, NgayToiDaMuon, NhaXuatBan);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật thất bại! Lỗi Đầu vào");
            }
            if (result == 0)
            {
                MessageBox.Show("Cập nhật Bại");
            }
            else
            {
                MessageBox.Show("Cập nhật Thành Công");
                LoadData();
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
           ;
            try
            {
                int Id = Int32.Parse(textBoxID.Text.Trim());
                result = proxy.XoaDauSach(Id);
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

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            String ChuoiTimKiem = textBoxTimKiem.Text.Trim();
            if (ChuoiTimKiem == null || ChuoiTimKiem == "")
            {
                MessageBox.Show("Nhập ISBN Hoặc Tên Sách Vào Ô Tìm Kiếm");
                return;
            }
            try
            {
                String strResult = proxy.TimDauSach(ChuoiTimKiem);
                DataTable dataSource = JsonConvert.DeserializeObject<DataTable>(strResult);
                LoadData();
                dataGridView.DataSource = dataSource;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePickerNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void QuanLyDauSach_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = dataGridView.CurrentCell.RowIndex;
                DataTable dataTable = (DataTable)dataGridView.DataSource;
                var row = dataTable.Rows[rowIndex];
                textBoxID.Text = row.Field<String>("Mã Đầu Sách");
                textBoxISBN.Text = row.Field<String>("ISBN");
                textBoxTenSach.Text = row.Field<String>("Tên Đầu Sách");
                foreach (var item in comboBoxNhaXuatBan.Items)
                {
                    if (item.Equals(row.Field<String>("Nhà Xuất Bản")))
                    {
                        comboBoxNhaXuatBan.SelectedItem = item;
                        break;
                    }
                }
                foreach (var item in comboBoxNN.Items)
                {
                    if (item.Equals(row.Field<String>("Ngôn Ngữ")))
                    {
                        comboBoxNN.SelectedItem = item;
                        break;
                    }
                }
                textBoxGiaBia.Text = row.Field<String>("Giá Bìa");
                textBoxKichThuoc.Text = row.Field<String>("Kích Thước");
                textBoxTrongLuong.Text = row.Field<String>("Trọng Lượng");
                numericUpDownNamXB.Value = Int32.Parse(row.Field<String>("Năm Xuất Bản"));
                numericUpDownSoTrang.Value = Int32.Parse(row.Field<String>("Số Trang"));
                numericUpDownNgayMuon.Value = Int32.Parse(row.Field<String>("Ngày Mượn Tối Đa"));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
