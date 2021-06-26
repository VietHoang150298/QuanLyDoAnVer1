using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("VaiTros")]
    public class VaiTro
    {
        [Key]
        [StringLength(20)]
        public string IdVaiTro { get; set; }
        [StringLength(50)]
        public string TenVaiTro { get; set; }
    }
}