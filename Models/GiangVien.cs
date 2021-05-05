namespace QuanLyDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GiangVien
    {
        [Key]
        public int IdGiangVien { get; set; }

        public string MaGiangVien { get; set; }

        public string HoDem { get; set; }

        public string Ten { get; set; }

        public string HoTen { get; set; }

        public string HomThu { get; set; }

        public string GhiChu { get; set; }

        public string DonViCongTac { get; set; }

        public string DienThoai { get; set; }

        public string MaBoMon { get; set; }
    }
}
