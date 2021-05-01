namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DeTai
    {
        public int Id { get; set; }

        public string MaDeTai { get; set; }

        public string TenDeTai { get; set; }

        public float? KetQua { get; set; }

        public string NhanXet { get; set; }
        public int? IdSinhVien { get; set; }

        public int? IdMonHoc { get; set; }

        public int? IdHoiDong { get; set; }

        public int? IdGvhdTheoky { get; set; }
        public string LinkFileBaoCaoCuoiCung { get; set; }
    }
}
