﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q.DomainModels
{
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentCourse { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StudentMobile { get; set; }
        public bool IsAdmin { get; set; }
    }
}
