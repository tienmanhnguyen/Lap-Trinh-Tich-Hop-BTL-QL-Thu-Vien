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
    public partial class DanhMucNXB : Form
    {
        localhost.ServiceQLThuVien service = new localhost.ServiceQLThuVien();
        DataTable table;

        private void LoadGridView()
        {
            try
            {
                string dulieu = service.LayDanhSachNXB();
                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgvNXB.DataSource = table;
                cbboxMaNXB.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public DanhMucNXB()
        {
            InitializeComponent();
        }

        private void DanhMucNXB_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string timkiem = cbboxTimKiem.Text;
                string dulieu = service.TimKiemNXB(timkiem);
                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgvNXB.DataSource = table;
                buttonBoQua.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ResetValue()
        {
            cbboxTimKiem.Text = "";
            cbboxMaNXB.Text = "";
            textBoxTenNXB.Text = "";
            textBoxDiaChi.Text = "";
            textBoxEmail.Text = "";
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {

            buttonSua.Enabled = false;
            buttonXoa.Enabled = false;
            buttonBoQua.Enabled = true;
            buttonLuu.Enabled = true;
            buttonThem.Enabled = false;
            ResetValue();                       //Xoá trắng các textbox
            cbboxMaNXB.Enabled = false;         //cho phép nhập mới
            cbboxMaNXB.Focus();

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbboxMaNXB.Text == "") //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (textBoxTenNXB.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn chưa nhập tên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (textBoxDiaChi.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Int32.Parse(cbboxMaNXB.Text.ToString());
                string dulieu = service.SuaNXB(id, textBoxTenNXB.Text.ToString(), textBoxDiaChi.Text.ToString(), textBoxEmail.Text.ToString());

                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgvNXB.DataSource = table;

                LoadGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ResetValue();
            buttonBoQua.Enabled = false;
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxTenNXB.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn phải nhập tên nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxTenNXB.Focus();
                    return;
                }
                if (textBoxDiaChi.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxDiaChi.Focus();
                    return;
                }

                string dulieu = service.ThemNXB(textBoxTenNXB.Text.ToString(), textBoxDiaChi.Text.ToString(), textBoxEmail.Text.ToString());

                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgvNXB.DataSource = table;

                LoadGridView(); //Nạp lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ResetValue();
            buttonXoa.Enabled = true;
            buttonThem.Enabled = true;
            buttonSua.Enabled = true;
            buttonBoQua.Enabled = false;
            buttonLuu.Enabled = false;
            cbboxMaNXB.Enabled = false;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {

            try
            {

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbboxMaNXB.Text == "") //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Int32.Parse(cbboxMaNXB.Text.ToString());
                    string dulieu = service.XoaNXB(id);

                    table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                    dgvNXB.DataSource = table;
                    LoadGridView();
                    ResetValue();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            buttonBoQua.Enabled = false;
            buttonThem.Enabled = true;
            buttonXoa.Enabled = true;
            buttonSua.Enabled = true;
            buttonLuu.Enabled = false;
            cbboxMaNXB.Enabled = false;
            textBoxTenNXB.Enabled = true;
            textBoxDiaChi.Enabled = true;
            textBoxEmail.Enabled = true;
            LoadGridView();
        }

        private void dgvNXB_Click(object sender, EventArgs e)
        {
            if (buttonThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbboxMaNXB.Focus();
                return;
            }
            if (table.Rows.Count == 0) //Nếu không có dữ liệu
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //cbboxMaNXB.Text = dgvNXB.CurrentRow.Cells["MaNXB"].Value.ToString();
                //textBoxTenNXB.Text = dgvNXB.CurrentRow.Cells["TenNXB"].Value.ToString();
                //textBoxDiaChi.Text = dgvNXB.CurrentRow.Cells["DiaChi"].Value.ToString();
                //textBoxEmail.Text = dgvNXB.CurrentRow.Cells["Email"].Value.ToString();

                int rowIndex = dgvNXB.CurrentCell.RowIndex;
                var row = table.Rows[rowIndex];
                cbboxMaNXB.Text = row.Field<String>("Mã NXB");
                textBoxTenNXB.Text = row.Field<String>("Tên NXB");
                textBoxDiaChi.Text = row.Field<String>("Địa chỉ");
                textBoxEmail.Text = row.Field<String>("Email");
            }
            catch (Exception)
            {
                
            }

            buttonSua.Enabled = true;
            buttonXoa.Enabled = true;
            buttonBoQua.Enabled = true;
        }
    }
}
