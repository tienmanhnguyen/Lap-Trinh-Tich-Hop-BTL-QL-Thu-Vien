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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void danhMucSachToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddForm(Form f)
        {
            this.panelNoiDung.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.panelNoiDung.Controls.Add(f);
            f.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            QuanLyDauSach ql = new QuanLyDauSach();
            AddForm(ql);
        }

        private void lamTheBanĐocToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
