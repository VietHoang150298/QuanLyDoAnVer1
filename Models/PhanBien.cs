namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PhanBien
    {
        [Key]
        public int IdPhanBien { get; set; }

        public string MaPhanBien { get; set; }

        public int? IdGiangVien { get; set; }

        public DateTime? ThoiKhoaBieu { get; set; }

        public int? KetQuaPhanBien { get; set; }

        public string NhanXet { get; set; }
    }
}
