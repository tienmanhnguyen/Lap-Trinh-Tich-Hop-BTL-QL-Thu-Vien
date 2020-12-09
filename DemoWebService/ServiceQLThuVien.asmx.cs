using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoWebService.Models;

using System.Web.Services;

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

            return a ;
        }

        [WebMethod]
        public int demslchude()
        {
            ChuDe cd = new ChuDe();
            int a = context.ChuDes.Count();

            return a;
        }




        //============================ Toan viet cho nay Oke Ban oi===================================













        //=================================  Loan Viet cho nay =================================
    }
}
