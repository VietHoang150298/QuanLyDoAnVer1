namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HocKys")]
    public partial class HocKy
    {
        [Key]
        public int IdHocKy { get; set; }

        public string MaHocKy { get; set; }

        [StringLength(50)]
        public string TenHocKy { get; set; }

        public DateTime NamBatDau { get; set; }

        public DateTime NamKetThuc { get; set; }
    }
}
