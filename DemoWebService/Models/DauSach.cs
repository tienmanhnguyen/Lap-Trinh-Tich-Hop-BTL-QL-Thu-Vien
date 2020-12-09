namespace DemoWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DauSach")]
    public partial class DauSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DauSach()
        {
            CuonSaches = new HashSet<CuonSach>();
            ChuDes = new HashSet<ChuDe>();
            TacGias = new HashSet<TacGia>();
        }

        public int Id { get; set; }

        [StringLength(11)]
        public string ISBN { get; set; }

        [StringLength(50)]
        public string TenDauSach { get; set; }

        public int? TrongLuong { get; set; }

        public double? GiaBia { get; set; }

        [StringLength(4)]
        public string NamXuatBan { get; set; }

        [StringLength(20)]
        public string KichThuoc { get; set; }

        public int? SoTrang { get; set; }

        [StringLength(10)]
        public string NgonNgu { get; set; }

        public int? Id_NhaXuatBan { get; set; }

        public int? SoNgayToiDaMuon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuonSach> CuonSaches { get; set; }

        public virtual NhaXuatBan NhaXuatBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChuDe> ChuDes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TacGia> TacGias { get; set; }
    }
}
