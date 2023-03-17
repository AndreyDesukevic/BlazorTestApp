using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Models
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<int>? OrdersId { get; set; }
        public ClientStatus ClientStatus { get; set; }
        public DateTime? DateCreate { get; set; }

    }
}
