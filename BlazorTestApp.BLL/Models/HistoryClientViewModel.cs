using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Models
{
    public class HistoryClientViewModel
    {
        public string? Description { get; set; }
        public ClientStatus ClientStatus { get; set; }
        public DateTime? DateOfChange { get; set; }
        public string UserName { get; set; }
    }
}
