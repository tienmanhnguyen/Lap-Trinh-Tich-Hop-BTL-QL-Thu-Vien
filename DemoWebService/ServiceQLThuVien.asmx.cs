using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoWebService.Models;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;
using System.Data.Entity;
using DemoWebService.Class;

namespace DemoWebService
{
    /// <summary>
    /// Summary description for ServiceQLThuVien
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceQLThuVien : System.Web.Services.WebService
    {

        MyContext context = new MyContext();
        DataTable table = new DataTable();

        //======================== Manh viet cho nay===================================

        // Phần quản lý nhà xuất bản

        [WebMethod]
        public string LayDanhSachNXB()
        {
            //var NXB = context.NhaXuatBans.ToList();

            //List<NhaXB> dsNXB = new List<NhaXB>();
            //foreach (NhaXuatBan nxb in NXB)
            //{
            //    NhaXB temp = new NhaXB();
            //    temp.Id = nxb.Id;
            //    temp.TenNhaXuatBan = nxb.TenNhaXuatBan;
            //    temp.DiaChi = nxb.DiaChi;
            //    temp.Email = nxb.Email;
            //    dsNXB.Add(temp);
            //}
            //String result = JsonConvert.SerializeObject(dsNXB);
            //return result;

           
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("STT");
                dataTable.Columns.Add("Mã NXB");
                dataTable.Columns.Add("Tên NXB");
                dataTable.Columns.Add("Địa chỉ");
                dataTable.Columns.Add("Email");

            var cts = context.NhaXuatBans.ToList();

                int i = 1;
                foreach (NhaXuatBan ct in cts)
                {
                    dataTable.Rows.Add(i, ct.Id, ct.TenNhaXuatBan, ct.DiaChi, ct.Email);
                    i++;
                }
                string result = JsonConvert.SerializeObject(dataTable);
            return result;      
        }

        [WebMethod]
        public string ThemNXB(String ten, String diaChi, String email)
        {
            NhaXuatBan nxb = new NhaXuatBan();
            nxb.TenNhaXuatBan = ten;
            nxb.DiaChi = diaChi;
            nxb.Email = email;

            try
            {
                context.NhaXuatBans.Add(nxb);
                context.SaveChanges();
            }
            catch (Exception) { }

            String result = LayDanhSachNXB();
            return result;
        }

        [WebMethod]
        public string SuaNXB(int id, String ten, String diaChi, String email)
        {
            NhaXuatBan nxb = context.NhaXuatBans.Where(x => x.Id.Equals(id)).FirstOrDefault();
            nxb.TenNhaXuatBan = ten;
            nxb.DiaChi = diaChi;
            nxb.Email = email;
            try
            {
                context.Entry(nxb).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception) { }

            String result = LayDanhSachNXB();
            return result;
        }

        [WebMethod]
        public string XoaNXB(int id)
        {
            NhaXuatBan nxb = context.NhaXuatBans.Where(x => x.Id.Equals(id)).FirstOrDefault();
            try
            {
                context.NhaXuatBans.Remove(nxb);
                context.SaveChanges();
            }
            catch (Exception) { }

            String result = LayDanhSachNXB();
            return result;
        }


        [WebMethod]
        public string TimKiemNXB(String timkiem)
        {
            timkiem = timkiem.Trim();
            try
            {
                int id = 0;
                if (IsNumber(timkiem) == true)
                {
                    id = Int32.Parse(timkiem);
                }
                var ds = context.NhaXuatBans.Where(x => x.Id == id || x.TenNhaXuatBan.Contains(timkiem)).ToList();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("STT");
                dataTable.Columns.Add("Mã NXB");
                dataTable.Columns.Add("Tên NXB");
                dataTable.Columns.Add("Địa chỉ");
                dataTable.Columns.Add("Email");

                int i = 1;
                foreach (NhaXuatBan ct in ds)
                {
                    dataTable.Rows.Add(i, ct.Id, ct.TenNhaXuatBan, ct.DiaChi, ct.Email);
                    i++;
                }
                string result = JsonConvert.SerializeObject(dataTable);
                return result;
            }
            catch (Exception) {
                return null;
            }
            
        }


        // Phân quản lý tác giả

        [WebMethod]
        public string LayDanhSachTacGia()
        {
            //var TG = context.TacGias.ToList();

            //List<TacGia2> ds = new List<TacGia2>();
            //foreach (TacGia tg in TG)
            //{
            //    TacGia2 temp = new TacGia2();
            //    temp.Id = tg.Id;
            //    temp.TenTacGia = tg.TenTacGia;
            //    temp.VaiTro = tg.VaiTro;
            //    temp.Email = tg.Email;
            //    ds.Add(temp);
            //}


            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("Mã tác giả");
            dataTable.Columns.Add("Tên tác giả");
            dataTable.Columns.Add("Vai trò");
            dataTable.Columns.Add("Email");

            var cts = context.TacGias.ToList();

            int i = 1;
            foreach (TacGia ct in cts)
            {
                dataTable.Rows.Add(i, ct.Id, ct.TenTacGia, ct.VaiTro, ct.Email);
                i++;
            }
            string result = JsonConvert.SerializeObject(dataTable);
            return result;
        }

        [WebMethod]
        public string ThemTG(String ten, String vaitro, String email)
        {
            TacGia tg = new TacGia();
            tg.TenTacGia = ten;
            tg.VaiTro = vaitro;
            tg.Email = email;
            try
            {
                context.TacGias.Add(tg);
                context.SaveChanges();
            }
            catch (Exception) { }

            String result = LayDanhSachTacGia();
            return result;
        }

        [WebMethod]
        public string SuaTG(int id, String ten, String vaitro, String email)
        {
            TacGia tg = context.TacGias.Where(x => x.Id.Equals(id)).FirstOrDefault();
            tg.TenTacGia = ten;
            tg.VaiTro = vaitro;
            tg.Email = email;
            try
            {
                context.Entry(tg).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception) { }

            String result = LayDanhSachTacGia();
            return result;
        }

        [WebMethod]
        public string XoaTG(int id)
        {
            TacGia tg = context.TacGias.Where(x => x.Id.Equals(id)).FirstOrDefault();
            try
            {
                context.TacGias.Remove(tg);
                context.SaveChanges();
            }
            catch (Exception) { }

            String result = LayDanhSachTacGia();
            return result;
        }


        [WebMethod]
        public string TimKiemTG(String timkiem)
        {
            try
            {
                //string sql = "select * from TacGia where id = N'" + timkiem + "' or TenTacGia = N'" + timkiem + "'";
                //var TG = context.TacGias.SqlQuery(sql).ToList();

                //List<TacGia2> ds = new List<TacGia2>();
                //foreach (TacGia tg in TG)
                //{
                //    TacGia2 temp = new TacGia2();
                //    temp.Id = tg.Id;
                //    temp.TenTacGia = tg.TenTacGia;
                //    temp.VaiTro = tg.VaiTro;
                //    temp.Email = tg.Email;
                //    ds.Add(temp);
                //}

                timkiem = timkiem.Trim();
                int id = 0;
                if(IsNumber(timkiem) == true)
                {
                    id = Int32.Parse(timkiem);
                }
                var ds = context.TacGias.Where(x => x.Id == id || x.TenTacGia.Contains(timkiem)).ToList();

                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("STT");
                dataTable.Columns.Add("Mã tác giả");
                dataTable.Columns.Add("Tên tác giả");
                dataTable.Columns.Add("Vai trò");
                dataTable.Columns.Add("Email");

                int i = 1;
                foreach (TacGia ct in ds)
                {
                    dataTable.Rows.Add(i, ct.Id, ct.TenTacGia, ct.VaiTro, ct.Email);
                    i++;
                }
                string result = JsonConvert.SerializeObject(dataTable);
                return result;
            }
            catch (Exception) { }
            return null;
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

        [WebMethod]
        public string PhieuMuon(string id)
        {
            if (IsNumber(id) == true)
            {
                int idPhieu = Int32.Parse(id);
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("STT");
                dataTable.Columns.Add("Mã cuốn sách");
                dataTable.Columns.Add("Tên sách");
                dataTable.Columns.Add("Ngày mượn");
                dataTable.Columns.Add("Ngày hẹn trả");

                var cts = (from s in context.ChiTietMuons
                           where s.PhieuMuon.Id == idPhieu
                           select s).ToArray<ChiTietMuon>();
                int i = 1;
                foreach (ChiTietMuon ct in cts)
                {
                    dataTable.Rows.Add(i, ct.CuonSach.Id, ct.CuonSach.DauSach.TenDauSach, ct.PhieuMuon.NgayMuon, ct.NgayHenTra);
                    i++;
                }
                string result = JsonConvert.SerializeObject(dataTable);
                return result;
            }
            return null;
        }



        [WebMethod]
        public string TinhTrangMuon(string id)
        {
            if (IsNumber(id) == true)
            {
                int idBanDoc = Int32.Parse(id);
                DataTable dataTable = new DataTable();

                dataTable.Columns.Add("STT");
                dataTable.Columns.Add("Mã cuốn sách");
                dataTable.Columns.Add("Tên sách");
                dataTable.Columns.Add("Mã phiếu mượn");
                dataTable.Columns.Add("Ngày mượn");
                dataTable.Columns.Add("Ngày hẹn trả");

                //var ct = context.ChiTietMuons.Where(x => x.TrangThai == false).ToList();

                var cts = (from s in context.ChiTietMuons
                           where s.TrangThai == false && s.PhieuMuon.BanDoc.Id == idBanDoc
                           select s).ToArray<ChiTietMuon>();
                int i = 1;
                foreach(ChiTietMuon ct  in cts)
                {
                    dataTable.Rows.Add(i, ct.CuonSach.Id, ct.CuonSach.DauSach.TenDauSach, ct.Id_PhieuMuon, ct.PhieuMuon.NgayMuon, ct.NgayHenTra);
                    i++;
                }
                string result = JsonConvert.SerializeObject(dataTable);
                return result;
            }
            return null;
        }

        [WebMethod]
        public string LayTenBanDoc(string id)
        {
            if (IsNumber(id) == true)
            {
                int idBanDoc = Int32.Parse(id);
                try
                {
                    BanDoc bd = context.BanDocs.Where(x => x.Id == idBanDoc).FirstOrDefault();
                    return bd.TenBanDoc;
                }
                catch (Exception) { }
            }
            return null;
        }

        [WebMethod]
        public int LayMaBanDoc(string id)
        {
            if (IsNumber(id) == true)
            {
                int idPhieu = Int32.Parse(id);
                try
                {
                    PhieuMuon pm = context.PhieuMuons.Where(x => x.Id == idPhieu).FirstOrDefault();
                    return (int)pm.Id_BanDoc;
                }
                catch (Exception) { }
            }
            return 0;
        }
        [WebMethod]
        public bool KTPhieuMuon(string id)
        {
            if (IsNumber(id) == true)
            {
                int idPhieu = Int32.Parse(id);
                try
                {
                    PhieuMuon pm = context.PhieuMuons.Where(x => x.Id == idPhieu).FirstOrDefault();
                    if(pm != null)
                    {
                        return true;
                    }
                }
                catch (Exception) { }
            }
            return false;
        }

        [WebMethod]
        public bool DangNhap(string ten, string matkhau)
        {
            try
            {
                Admin ad = context.Admins.Where(x => x.UserName == ten && x.Pass == matkhau).FirstOrDefault();
                if(ad != null)
                {
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }

        //============================ Toan viet cho nay===================================













        //=================================  Loan Viet cho nay =================================
    }
}
