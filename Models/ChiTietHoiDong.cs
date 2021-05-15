namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChiTietHoiDong
    {
        [Key]
        public int IdChiTietHoiDong { get; set; }

        [StringLength(50)]
        public string MaHoiDong { get; set; }

        [StringLength(50)]
        public string MaGiangVien1 { get; set; }

        [StringLength(50)]
        public string MaGiangVien2 { get; set; }

        [StringLength(50)]
        public string MaGiangVien3 { get; set; }

        [StringLength(50)]
        public string MaGiangVien4 { get; set; }

        [StringLength(50)]
        public string MaGiangVien5 { get; set; }
    }
}
