using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebService.Class
{
    public class NhaXB
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TenNhaXuatBan { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}