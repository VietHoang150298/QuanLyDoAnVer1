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
        public string MaGiangVien { get; set; }
    }
}