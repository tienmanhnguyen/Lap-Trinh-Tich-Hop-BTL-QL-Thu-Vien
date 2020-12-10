using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoWebService.Class
{
    public class TacGia2
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string TenTacGia { get; set; }

        [StringLength(50)]
        public string VaiTro { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}