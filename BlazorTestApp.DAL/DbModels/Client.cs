using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.DbModels
{
    public class Client : BaseModel
    {
        [Required]
        [StringLength(16, ErrorMessage = "FirstName is too long.")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(16, ErrorMessage = "LastName is too long.")]
        public string? LastName { get; set; }
        public DateTime DateCreate { get; set; }
        public ClientStatus ClientStatus { get; set; }
        public List<Order> Orders { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }
       
    }
}
