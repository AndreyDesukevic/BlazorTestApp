using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string? NameClient { get; set; }
        public string? Description { get; set; }
        public int Cost { get; set; }
        public DateTime OrderData { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
