using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("PhanBienDeTais")]
    public class PhanBienDeTai
    {
        [Key]
        public int IdPhanBienDeTai { get; set; }
        public string MaHocKy { get; set; }
        public string MaGiangVien { get; set; }
        public string MaDeTai { get; set; }
    }
}