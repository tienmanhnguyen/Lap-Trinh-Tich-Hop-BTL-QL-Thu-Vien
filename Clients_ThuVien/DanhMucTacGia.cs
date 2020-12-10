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
    public partial class DanhMucTacGia : Form
    {
        localhost.ServiceQLThuVien service = new localhost.ServiceQLThuVien();
        DataTable table;

        private void LoadGridView()
        {
            try
            {
                string dulieu = service.LayDanhSachTacGia();
                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgvTacGia.DataSource = table;
                textboxMaTG.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DanhMucTacGia()
        {
            InitializeComponent();
        }

        private void DanhMucTacGia_Load(object sender, EventArgs e)
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

                    string dulieu = service.TimKiemTG(timkiem);
                    table = JsonConvert.DeserializeObject<DataTable>(dulieu);
                dgvTacGia.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                

            dgvTacGia.DataSource = table;
            buttonBoQua.Enabled = true;
        }

        private void ResetValue()
        {
            cbboxTimKiem.Text = "";
            textboxMaTG.Text = "";
            textBoxTenTG.Text = "";
            textBoxVaiTro.Text = "";
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
            textboxMaTG.Enabled = false;         //cho phép nhập mới
            textboxMaTG.Focus();
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
                if (textboxMaTG.Text == "") //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (textBoxTenTG.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn chưa nhập tên ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int id = Int32.Parse(textboxMaTG.Text.ToString());
                string dulieu = service.SuaTG(id, textBoxTenTG.Text.ToString(), textBoxVaiTro.Text.ToString(), textBoxEmail.Text.ToString());

                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgvTacGia.DataSource = table;

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
                if (textBoxTenTG.Text.Trim().Length == 0) //Nếu chưa nhập tên chất liệu
                {
                    MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxTenTG.Focus();
                    return;
                }

                string dulieu = service.ThemTG(textBoxTenTG.Text.ToString(), textBoxVaiTro.Text.ToString(), textBoxEmail.Text.ToString());

                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgvTacGia.DataSource = table;

                LoadGridView(); //Nạp lại DataGridView
                ResetValue();
                buttonXoa.Enabled = true;
                buttonThem.Enabled = true;
                buttonSua.Enabled = true;
                buttonBoQua.Enabled = false;
                buttonLuu.Enabled = false;
                textboxMaTG.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                if (textboxMaTG.Text == "") //nếu chưa chọn bản ghi nào
                {
                    MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Int32.Parse(textboxMaTG.Text.ToString());
                    string dulieu = service.XoaTG(id);

                    table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                    dgvTacGia.DataSource = table;
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
            textboxMaTG.Enabled = false;
            textBoxTenTG.Enabled = true;
            textBoxVaiTro.Enabled = true;
            textBoxEmail.Enabled = true;
            LoadGridView();
        }

        private void dgvTacGia_Click(object sender, EventArgs e)
        {
            try
            {
                if (buttonThem.Enabled == false)
                {
                    MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textboxMaTG.Focus();
                    return;
                }
                if (table.Rows.Count == 0) //Nếu không có dữ liệu
                {
                    MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                int rowIndex = dgvTacGia.CurrentCell.RowIndex;
                var row = table.Rows[rowIndex];
                textboxMaTG.Text = row.Field<String>("Mã tác giả");
                textBoxTenTG.Text = row.Field<String>("Tên tác giả");
                textBoxVaiTro.Text = row.Field<String>("Vai trò");
                textBoxEmail.Text = row.Field<String>("Email");

                buttonSua.Enabled = true;
                buttonXoa.Enabled = true;
                buttonBoQua.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
