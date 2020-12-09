using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace WebService_QLSinhVien.Class
{
    class Func
    {
        public static SqlConnection Con;  //Khai báo đối tượng kết nối        

        public static void Connect()
        {
            try
            {
                Con = new SqlConnection();   //Khởi tạo đối tượng
                Con.ConnectionString = "Data Source=DESKTOP-AN05VTG;Initial Catalog=QuanLySinhVen_WebService;Integrated Security=True";
                Con.Open();                  //Mở kết nối
                                             //Kiểm tra kết nối
                if (Con.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Kết nối thành công đến SQL Server!");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Kết nối đến Server bị lỗi!");
            }
        }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();   	//Đóng kết nối
                Con.Dispose(); 	//Giải phóng tài nguyên
                Con = null;
            }
        }
        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            DataTable table = new DataTable();                 //Khai báo đối tượng table thuộc lớp DataTable
            dap.Fill(table);                                   //Đổ kết quả từ câu lệnh sql vào table
            return table;
        }

        public static void RunSQL(string sql)
        {
            SqlCommand cmd; //Đối tượng thuộc lớp SqlCommand
            cmd = new SqlCommand();
            cmd.Connection = Con; //Gán kết nối
            cmd.CommandText = sql; //Gán lệnh SQL
            try
            {
                cmd.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();//Giải phóng bộ nhớ
            cmd = null;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Func.Con;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Dữ liệu đang được dùng, không thể xoá...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            cmd.Dispose();
            cmd = null;
        }
    }
}
