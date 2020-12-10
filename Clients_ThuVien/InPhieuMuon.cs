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
    public partial class InPhieuMuon : Form
    {
        localhost.ServiceQLThuVien service = new localhost.ServiceQLThuVien();
        DataTable table;
        public InPhieuMuon()
        {
            InitializeComponent();
        }

        private void LoadGridView(string id)
        {
            try
            {
                string dulieu = service.PhieuMuon(id);
                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgv.DataSource = table;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
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

        public static string Get_Day()
        {
            string str = DateTime.Now.ToString().Trim();
            str = str.Substring(0, 2);
            return str;
        }
        public static string Get_Month()
        {
            string str = DateTime.Now.ToString().Trim();
            str = str.Substring(3, 2);
            return str;
        }
        public static string Get_Year()
        {
            string str = DateTime.Now.ToString().Trim();
            str = str.Substring(6, 4);
            return str;
        }

        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = cbboxTimKiem.Text;
                if (IsNumber(ma) == true)
                {
                    if (service.KTPhieuMuon(ma) == false)
                    {
                        MessageBox.Show("Phiếu mượn không tồn tại");
                    }
                    else
                    {
                        string ngaybaocao = "Ngày " + Get_Day() + " tháng " + Get_Month()
                                  + " năm " + Get_Year();
                        labelNgayHienTai.Text = ngaybaocao;
                        labelMaPhieu.Text = ma;
                        labelMaBanDoc.Text = (service.LayMaBanDoc(ma)).ToString();
                        labelTenBanDoc.Text = service.LayTenBanDoc((service.LayMaBanDoc(ma)).ToString());
                        LoadGridView(ma);
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào số");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
