using BlazorTestApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Search.Interfaces
{
    public interface ISearchOrder
    {
        IEnumerable<OrderViewModel> SearchByName(string searchTerm);
    }
}
