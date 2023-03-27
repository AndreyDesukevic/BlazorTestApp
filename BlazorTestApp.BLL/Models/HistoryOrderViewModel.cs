using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Models
{
    public class HistoryOrderViewModel
    {
        public string? Description { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime? DateOfChange { get; set; }
        public string UserName { get; set; }
    }
}
