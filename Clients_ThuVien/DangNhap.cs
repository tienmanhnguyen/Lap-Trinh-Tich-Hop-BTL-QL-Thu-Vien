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
    public partial class DangNhap : Form
    {
        localhost.ServiceQLThuVien service = new localhost.ServiceQLThuVien();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonDangNhap_Click(object sender, EventArgs e)
        {

            try
            {
                string ten = txtTen.Text;
                string mk = txtMk.Text;

                if (service.DangNhap(ten, mk) == true)
                {
                    menuStrip1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
