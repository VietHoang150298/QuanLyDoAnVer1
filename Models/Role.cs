using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyDoAn.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        [StringLength(20)]
        public string RoleId { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; }
    }
}