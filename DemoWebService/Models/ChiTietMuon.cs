namespace DemoWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietMuon")]
    public partial class ChiTietMuon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_CuonSach { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_PhieuMuon { get; set; }

        public bool? TrangThai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHenTra { get; set; }

        public virtual CuonSach CuonSach { get; set; }

        public virtual PhieuMuon PhieuMuon { get; set; }
    }
}
