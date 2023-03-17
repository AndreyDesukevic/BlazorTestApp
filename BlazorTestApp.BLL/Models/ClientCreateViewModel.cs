using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Models
{
    public class ClientCreateViewModel
    {
        [Required]
        [StringLength(16, ErrorMessage = "FirstName is too long.")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(16, ErrorMessage = "LastName is too long.")]
        public string? LastName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }

    }
}
