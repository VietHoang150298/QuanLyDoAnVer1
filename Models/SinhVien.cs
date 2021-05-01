namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SinhVien
    {
        public int Id { get; set; }

        public string MaSinhVien { get; set; }

        public string HoDem { get; set; }

        public string Ten { get; set; }

        public string HoTen { get; set; }

        public string HomThu { get; set; }

        public string IdLop { get; set; }

        public string MaLop { get; set; }

        public string DienThoai { get; set; }

        public int? TinChiTichLuy { get; set; }

        public float? DiemTichLuy { get; set; }
    }
}
