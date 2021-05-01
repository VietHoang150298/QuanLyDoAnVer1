namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HoiDongDanhGiaKQ
    {
        public int Id { get; set; }

        public string MaHoiDong { get; set; }

        public string TenHoiDong { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ThoiKhoaBieu { get; set; }

        public int? KetQuaCaNhan { get; set; }

        public string NhanXet { get; set; }

        public int? IdGiangVien { get; set; }

        public int? IdPhanBien { get; set; }

        public int? IdHocKy { get; set; }
    }
}
