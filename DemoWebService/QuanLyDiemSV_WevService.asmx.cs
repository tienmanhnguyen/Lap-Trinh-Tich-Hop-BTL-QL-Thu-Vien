using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebService_QLSinhVien.Class;
using System.Data;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace DemoWebService
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]


    public class QuanLyDiemSV_WevService : System.Web.Services.WebService
    {
        DataTable bangDiemThi = new DataTable();
        DBAccess myConnect = new DemoWebService.DBAccess();
        
        [WebMethod]
        public void ThemDiem(String maSV, String maMonHoc, float diemthi)
        {

        }

        [WebMethod]
        public string XemDiemThi()
        {
            String query = "Select *from DiemThi_SinhVien";
            myConnect.readDatathroughAdapter(query, bangDiemThi);

            string result = JsonConvert.SerializeObject(bangDiemThi);
            return result;
        }
        [WebMethod]
        public string TimKiemDiemSinhVien(string id)
        {
            String query = "Select *from DiemThi_SinhVien where MaSV = '" + id +"'" ;
            myConnect.readDatathroughAdapter(query, bangDiemThi);

            string result = JsonConvert.SerializeObject(bangDiemThi);
            return result;
        }

        [WebMethod]
        public string ThemDiemThi(string maSV, string maMH, string diemThi)
        {
            String query = "Insert into DiemThi_SinhVien Values('"+ maSV + "', '"+ maMH + "', '"+ diemThi +"')";
            myConnect.RunSQL(query);

            string result = JsonConvert.SerializeObject(bangDiemThi);
            return result;
        }
        [WebMethod]
        public string SuaDiemThi(string maSV, string maMH, string diemThi)
        {
            String query = "Update DiemThi_SinhVien set DiemThi = '" +diemThi + "' where MaSV = '"+ maSV +"' and MaMonHoc='"+maMH+"'";
            myConnect.RunSQL(query);

            string result = JsonConvert.SerializeObject(bangDiemThi);
            return result;
        }
        [WebMethod]
        public string XoaDiemThi(string maSV, string maMH)
        {
            String query = "Delete from DiemThi_SinhVien where MaSV='" + maSV +"' and MaMonHoc='"+maMH +"'";
            myConnect.RunSQL(query);

            string result = JsonConvert.SerializeObject(bangDiemThi);
            return result;
        }
    }
}
