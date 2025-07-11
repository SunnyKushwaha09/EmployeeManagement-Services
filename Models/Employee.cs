﻿using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Models
{
    public class Employee
    {
            
        public int Id { get; set; }
        
        [Required(ErrorMessage ="First Name is required")]
            
        public string FirstName { get; set; }
        [Required(ErrorMessage = "last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "POsition is required")]
        public string Position { get; set; }
      

    }
}
