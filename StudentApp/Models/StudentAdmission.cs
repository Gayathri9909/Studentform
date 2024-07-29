using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentApp.Models
{
    public class StudentAdmission
    {
        [Key]
        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

     
        public DateTime DateOfBirth { get; set; }

       
        public string phoneNumber { get; set; }

      
        public string Address { get; set; }

        public string Course { get; set; }

        public byte[] Photo { get; set; }

        public byte[] Resume { get; set; }

        public List<StudentAdmission> ShowallStudent { get; set; }
    }
}
