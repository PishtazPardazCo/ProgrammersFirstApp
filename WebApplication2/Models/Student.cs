using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        public int StudentCode { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public int IdMajor { get; set; }
        public virtual Major Major { get; set; }
        
    }
}