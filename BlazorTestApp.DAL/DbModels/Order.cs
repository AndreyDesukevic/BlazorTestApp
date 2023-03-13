using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.DbModels
{
    public class Order:BaseModel
    { 
        public Client? Client { get; set; }
        public string? Decsription { get; set; }
        public DateTime OrderData { get; set; }
        public decimal Cost { get; set; }
        public OrderStatus OrderStatus { get; set; }
       
    }
}
