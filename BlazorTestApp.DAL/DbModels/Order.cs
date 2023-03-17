using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.DbModels
{
    public class Order:BaseModel
    { 
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Description is too long.")]
        public string? Description { get; set; }
        public DateTime OrderData { get; set; }

        [Range(1, 300000, ErrorMessage = "Сost is not valid")]
        public int Cost { get; set; }
        public OrderStatus OrderStatus { get; set; }
       
    }
}
