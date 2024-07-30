using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.Models
{
    public class StudentAdmission
    {
        [Key]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string phoneNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; }

        [Display(Name = "Photo")]
        public byte[] Photo { get; set; }

        [Display(Name = "Resume")]
        public byte[] Resume { get; set; }

        // This is a collection property and doesn't need a display name for individual items.
        public List<StudentAdmission> ShowallStudent { get; set; }
    }
}
