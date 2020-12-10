using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoWebService.Models;
using Newtonsoft.Json;
using System.Web.Services;
using System.Data;
using System.Collections;

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

        //======================== Manh viet cho nay===================================

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string QLSach(String tencd)
        {
            ChuDe cd = new ChuDe();
            cd.TenChuDe = tencd;
            context.ChuDes.Add(cd);
            context.SaveChanges();

            return tencd;
        }

        [WebMethod]
        public int DemChuDe()
        {
            ChuDe cd = new ChuDe();
            int a = context.ChuDes.Count();

            return a;
        }

        [WebMethod]
        public int demslchude()
        {
            ChuDe cd = new ChuDe();
            int a = context.ChuDes.Count();

            return a;
        }




        //============================ Toan viet cho nay Oke Ban oi===================================

        [WebMethod]
        public String DanhSachBanDoc()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("Mã Bạn Đọc");
            dataTable.Columns.Add("Họ Và Tên");
            dataTable.Columns.Add("Số Điện Thoại");
            dataTable.Columns.Add("Địa Chỉ");
            dataTable.Columns.Add("Giới Tính");
            dataTable.Columns.Add("Ngày Sinh");
         

            try
            {
                BanDoc[] result;
                var bds = from s in context.BanDocs
                          select s;
                result = bds.ToArray<BanDoc>();


                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].GioiTinh == true)
                    {
                        dataTable.Rows.Add(i, result[i].Id, result[i].TenBanDoc, result[i].SoDienThoai, result[i].DiaChi, "Nam", result[i].NgaySinh);
                    }
                    else
                    {
                        dataTable.Rows.Add(i, result[i].Id, result[i].TenBanDoc, result[i].SoDienThoai, result[i].DiaChi, "Nữ", result[i].NgaySinh);
                    }

                }
            }
            catch (Exception ex) { }

            return JsonConvert.SerializeObject(dataTable);
        }


        [WebMethod]
        public int ThemBanDoc(String HoVaTen, String SoDienThoai, String DiaChi, bool GioiTinh, DateTime NgaySinh)
        {
            int result = 0;
            BanDoc bd = new BanDoc();
            bd.TenBanDoc = HoVaTen;
            bd.SoDienThoai = SoDienThoai;
            bd.DiaChi = DiaChi;
            bd.GioiTinh = GioiTinh;
            bd.NgaySinh = NgaySinh;

            try
            {

                context.BanDocs.Add(bd);
                result = context.SaveChanges();
            }
            catch (Exception e) { }
            return result;

        }


        [WebMethod]
        public String TimBanDoc(String ChuoiTimKiem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("Mã Bạn Đọc");
            dataTable.Columns.Add("Họ Và Tên");
            dataTable.Columns.Add("Số Điện Thoại");
            dataTable.Columns.Add("Địa Chỉ");
            dataTable.Columns.Add("Giới Tính");
            dataTable.Columns.Add("Ngày Sinh");
        

            try
            {
                BanDoc[] result;
                var bds = from s in context.BanDocs
                          where (s.TenBanDoc.Contains(ChuoiTimKiem) || s.SoDienThoai.Contains(ChuoiTimKiem))
                          select s;
                result = bds.ToArray<BanDoc>();


                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].GioiTinh == true)
                    {
                        dataTable.Rows.Add(i, result[i].Id, result[i].TenBanDoc, result[i].SoDienThoai, result[i].DiaChi, "Nam", result[i].NgaySinh);
                    }
                    else
                    {
                        dataTable.Rows.Add(i, result[i].Id, result[i].TenBanDoc, result[i].SoDienThoai, result[i].DiaChi, "Nữ", result[i].NgaySinh);
                    }

                }
            }
            catch (Exception ex) { }

            return JsonConvert.SerializeObject(dataTable);
        }


        [WebMethod]
        public int XoaBanDoc(int id)
        {
            try
            {
                BanDoc bd = context.BanDocs.SingleOrDefault(x => x.Id == id);
                context.BanDocs.Remove(bd);
                return context.SaveChanges();

            }
            catch (Exception ex) { }

            return 0;
        }


        [WebMethod]
        public int CapNhatBanDoc(int Id, String HoVaTen, String SoDienThoai, String DiaChi, bool GioiTinh, DateTime NgaySinh)
        {
            try
            {
                var bd = context.BanDocs.SingleOrDefault(x => x.Id == Id);

                bd.TenBanDoc = HoVaTen;
                bd.SoDienThoai = SoDienThoai;
                bd.DiaChi = DiaChi;
                bd.GioiTinh = GioiTinh;
                bd.NgaySinh = NgaySinh;
                return context.SaveChanges();
            }
            catch (Exception ex) { }

            return 0;
        }




        [WebMethod]
        public String DanhSachDauSach()
        {


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("Mã Đầu Sách");
            dataTable.Columns.Add("ISBN");
            dataTable.Columns.Add("Tên Đầu Sách");
            dataTable.Columns.Add("Nhà Xuất Bản");
            dataTable.Columns.Add("Ngôn Ngữ");
            dataTable.Columns.Add("Giá Bìa");
            dataTable.Columns.Add("Trọng Lượng");
            dataTable.Columns.Add("Năm Xuất Bản");
            dataTable.Columns.Add("Kích Thước");
            dataTable.Columns.Add("Số Trang");
            dataTable.Columns.Add("Ngày Mượn Tối Đa");
            

            try
            {
                DauSach[] result;
                var dss = from s in context.DauSaches
                          select s;
                result = dss.ToArray<DauSach>();
                for (int i = 0; i < result.Length; i++)
                {


                    dataTable.Rows.Add(i, result[i].Id, result[i].ISBN, result[i].TenDauSach, result[i].NhaXuatBan.TenNhaXuatBan, result[i].NgonNgu,
                        result[i].GiaBia, result[i].TrongLuong, result[i].NamXuatBan, result[i].KichThuoc, result[i].SoTrang, result[i].SoNgayToiDaMuon);


                }
            }
            catch (Exception ex) { }

            return JsonConvert.SerializeObject(dataTable);
        }


        [WebMethod]
        public int ThemDauSach(String ISBN, String TenDauSach, String NamXuatBan, String KichThuoc, String NgonNgu, int TrongLuong, double GiaBia, int SoTrang, int SoNgayToiDaMuon, String TenNhaXuatBan)
        {
            int result = 0;
            try
            {
                DauSach ds = new DauSach();
                ds.ISBN = ISBN;
                ds.TenDauSach = TenDauSach;
                ds.NamXuatBan = NamXuatBan;
                ds.KichThuoc = KichThuoc;
                ds.NgonNgu = NgonNgu;
                ds.TrongLuong = TrongLuong;
                ds.GiaBia = GiaBia;
                ds.SoTrang = SoTrang;
                ds.SoNgayToiDaMuon = SoNgayToiDaMuon;

                NhaXuatBan nxb = (from s in context.NhaXuatBans
                                  where s.TenNhaXuatBan.Equals(TenNhaXuatBan)
                                  select s).Single();

                ds.NhaXuatBan = nxb;


                context.DauSaches.Add(ds);
                result = context.SaveChanges();
            }
            catch (Exception e) { }
            return result;

        }


        [WebMethod]
        public String TimDauSach(String ChuoiTimKiem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("Mã Đầu Sách");
            dataTable.Columns.Add("ISBN");
            dataTable.Columns.Add("Tên Đầu Sách");
            dataTable.Columns.Add("Nhà Xuất Bản");
            dataTable.Columns.Add("Ngôn Ngữ");
            dataTable.Columns.Add("Giá Bìa");
            dataTable.Columns.Add("Trọng Lượng");
            dataTable.Columns.Add("Năm Xuất Bản");
            dataTable.Columns.Add("Kích Thước");
            dataTable.Columns.Add("Số Trang");
            dataTable.Columns.Add("Ngày Mượn Tối Đa");

            try
            {
                DauSach[] result;
                var dss = from s in context.DauSaches
                          where s.ISBN.Contains(ChuoiTimKiem) || s.TenDauSach.Contains(ChuoiTimKiem)
                          select s;
                result = dss.ToArray<DauSach>();
                for (int i = 0; i < result.Length; i++)
                {


                    dataTable.Rows.Add(i, result[i].Id, result[i].ISBN, result[i].TenDauSach, result[i].NhaXuatBan.TenNhaXuatBan, result[i].NgonNgu,
                        result[i].GiaBia, result[i].TrongLuong, result[i].NamXuatBan, result[i].KichThuoc, result[i].SoTrang, result[i].SoNgayToiDaMuon);


                }
            }
            catch (Exception ex) { }

            return JsonConvert.SerializeObject(dataTable);
        }


        [WebMethod]
        public int XoaDauSach(int id)
        {
            try
            {
                DauSach ds = context.DauSaches.SingleOrDefault(x => x.Id == id);
                context.DauSaches.Remove(ds);
                return context.SaveChanges();

            }
            catch (Exception ex) { }

            return 0;
        }


        [WebMethod]
        public int CapNhatDauSach(int Id, String ISBN, String TenDauSach, String NamXuatBan, String KichThuoc, String NgonNgu, int TrongLuong, double GiaBia, int SoTrang, int SoNgayToiDaMuon, String TenNhaXuatBan)
        {
            try
            {
                var ds = context.DauSaches.SingleOrDefault(x => x.Id == Id);

                ds.ISBN = ISBN;
                ds.TenDauSach = TenDauSach;
                ds.NamXuatBan = NamXuatBan;
                ds.KichThuoc = KichThuoc;
                ds.NgonNgu = NgonNgu;
                ds.TrongLuong = TrongLuong;
                ds.GiaBia = GiaBia;
                ds.SoTrang = SoTrang;
                ds.SoNgayToiDaMuon = SoNgayToiDaMuon;

                NhaXuatBan nxb = (from s in context.NhaXuatBans
                                  where s.TenNhaXuatBan.Equals(TenNhaXuatBan)
                                  select s).Single();

                ds.NhaXuatBan = nxb;
                return context.SaveChanges();

            }
            catch (Exception ex) { }

            return 0;
        }


        [WebMethod]
        public String DanhSachCuonSach()
        {


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("Mã Cuốn Sách");
            dataTable.Columns.Add("Số Đánh Nhãn");
            dataTable.Columns.Add("ISBN");
            dataTable.Columns.Add("Tên Đầu Sách");
            dataTable.Columns.Add("Nhà Xuất Bản");
            dataTable.Columns.Add("Ngôn Ngữ");

            try
            {
                CuonSach[] result;
                var dss = from s in context.CuonSaches
                          select s;
                result = dss.ToArray<CuonSach>();
                for (int i = 0; i < result.Length; i++)
                {


                    dataTable.Rows.Add(i + 1, result[i].Id, result[i].SoDanhNhan, result[i].DauSach.ISBN, result[i].DauSach.TenDauSach, result[i].DauSach.NhaXuatBan.TenNhaXuatBan, result[i].DauSach.NgonNgu);


                }
            }
            catch (Exception ex) { }

            return JsonConvert.SerializeObject(dataTable);
        }


        [WebMethod]
        public int ThemCuonSach(String ISBN, String SoDanhNhan)
        {
            int result = 0;
            try
            {
                CuonSach cs = new CuonSach();
                cs.SoDanhNhan = SoDanhNhan;

                DauSach ds = (from s in context.DauSaches
                              where s.ISBN.Equals(ISBN)
                              select s).Single();

                cs.DauSach = ds;
                context.CuonSaches.Add(cs);
                result = context.SaveChanges();
            }
            catch (Exception e) { }
            return result;

        }


        [WebMethod]
        public String TimCuonSach(String ChuoiTimKiem)
        {

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("STT");
            dataTable.Columns.Add("Mã Cuốn Sách");
            dataTable.Columns.Add("Số Đánh Nhãn");
            dataTable.Columns.Add("ISBN");
            dataTable.Columns.Add("Tên Đầu Sách");
            dataTable.Columns.Add("Nhà Xuất Bản");
            dataTable.Columns.Add("Ngôn Ngữ");
          
            try
            {
                CuonSach[] result;
                var dss = from s in context.CuonSaches
                          where s.SoDanhNhan.Contains(ChuoiTimKiem) || s.DauSach.ISBN.Contains(ChuoiTimKiem) || s.DauSach.TenDauSach.Contains(ChuoiTimKiem)
                          select s;
                result = dss.ToArray<CuonSach>();
                for (int i = 0; i < result.Length; i++)
                {


                    dataTable.Rows.Add(i + 1, result[i].Id, result[i].SoDanhNhan, result[i].DauSach.ISBN, result[i].DauSach.TenDauSach, result[i].DauSach.NhaXuatBan.TenNhaXuatBan, result[i].DauSach.NgonNgu);


                }
            }
            catch (Exception ex) { }

            return JsonConvert.SerializeObject(dataTable);
        }


        [WebMethod]
        public int XoaCuonSach(int id)
        {
            try
            {
                CuonSach ds = context.CuonSaches.SingleOrDefault(x => x.Id == id);
                context.CuonSaches.Remove(ds);
                return context.SaveChanges();

            }
            catch (Exception ex) { }

            return 0;
        }


        [WebMethod]
        public int CapNhatCuonSach(int Id, String SoDanhNhan, String ISBN)
        {
            try
            {
                var ds = context.CuonSaches.Single(x => x.Id == Id);

                ds.SoDanhNhan = SoDanhNhan;
                DauSach dauSach = (from s in context.DauSaches
                                   where s.ISBN.Equals(ISBN)
                                   select s).Single();

                ds.DauSach = dauSach;
                return context.SaveChanges();

            }
            catch (Exception ex) { }

            return 0;
        }

        [WebMethod]
        public String danhSachNhaXuatBan()
        {
            var arr = new ArrayList();
            try
            {
                NhaXuatBan[]  list;
                list = (from s in context.NhaXuatBans
                        select s).ToArray<NhaXuatBan>();
                for( int i=0; i < list.Length; i++)
                {
                    arr.Add(list[i].TenNhaXuatBan);
                }
                return JsonConvert.SerializeObject(arr);
            }catch( ExecutionEngineException ex) { }
            return null;
        }


        //=================================  Loan Viet cho nay =================================
    }
}
