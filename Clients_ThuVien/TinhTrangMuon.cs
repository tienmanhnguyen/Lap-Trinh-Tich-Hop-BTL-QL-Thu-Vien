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
    public partial class TinhTrangMuon : Form
    {
        localhost.ServiceQLThuVien service = new localhost.ServiceQLThuVien();
        DataTable table;

        public TinhTrangMuon()
        {
            InitializeComponent();
        }

        private void LoadGridView(string id)
        {
            try
            {
                string dulieu = service.TinhTrangMuon(id);
                table = JsonConvert.DeserializeObject<DataTable>(dulieu);

                dgv.DataSource = table;
            }
            catch (Exception ex)
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

        private void buttonTaoTK_Click(object sender, EventArgs e)
        {
            try
            {
                string maBanDoc = cbboxMaBanDoc.Text;
                if(IsNumber(maBanDoc)== true)
                {
                    
                    labelMaBanDoc.Text = maBanDoc;
                    string tenBanDoc = service.LayTenBanDoc(maBanDoc);
                    labelTenBanDoc.Text = tenBanDoc;
                    if(tenBanDoc == null)
                    {
                        MessageBox.Show("Không tồn tại bạn đọc");
                    }
                    else
                    {
                        string ngaybaocao = "Ngày " + Get_Day() + " tháng " + Get_Month()
                                  + " năm " + Get_Year();
                        labelNgayHienTai.Text = ngaybaocao;
                        LoadGridView(maBanDoc);
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào số");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
