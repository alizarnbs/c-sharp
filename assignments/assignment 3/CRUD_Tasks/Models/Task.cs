using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Tasks.Models
{
    public class Task
    {
        [Required(ErrorMessage = "Enter title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Enter description")]
        public string description { get; set; }
        [Required(ErrorMessage = "Enter status")]
        public string status { get; set; }
        [Required(ErrorMessage = "Enter priority")]
        public string priority { get; set; }
    }
}
