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
        [StringLength(50)]
        public string MaGiangVien { get; set; }
        [StringLength(50)]
        public string MaDeTai { get; set; }
        [StringLength(50)]
        public string MaMonHoc { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? ThoiKhoaBieu { get; set; }
    }
}