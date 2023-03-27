using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Models
{
    public class OrderCreateViewModel
    {
        public int ClientId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }
        [Range(1, 300000, ErrorMessage = "Сost is not valid")]
        public int Cost { get; set; }
        public string NameUserMadeChangeOrder { get; set; }
    }
}
