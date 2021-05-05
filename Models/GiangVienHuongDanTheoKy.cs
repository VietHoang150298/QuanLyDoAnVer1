namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiangVienHuongDanTheoKys")]
    public partial class GiangVienHuongDanTheoKy
    {
        [Key]
        public int IdGVHD { get; set; }

        public int? IdGiangVien { get; set; }

        public int? IdHocKy { get; set; }

        public int? SoLuongSinhVienHuongDan { get; set; }
    }
}
