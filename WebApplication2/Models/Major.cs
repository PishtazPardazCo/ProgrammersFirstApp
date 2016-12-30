using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Major
    {
        [Key]
        [Display(Name = "كد رشته")]
        public int IdMajor { get; set; }
        [Required(ErrorMessage = "الزامي")]
        [Display(Name = "رشته")]
        public string MajorName { get; set; }

        public virtual List<Student> Students { get; set; }
    }
}