namespace DemoWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CuonSach")]
    public partial class CuonSach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuonSach()
        {
            ChiTietMuons = new HashSet<ChiTietMuon>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string SoDanhNhan { get; set; }

        public int? Id_DauSach { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietMuon> ChiTietMuons { get; set; }

        public virtual DauSach DauSach { get; set; }
    }
}
