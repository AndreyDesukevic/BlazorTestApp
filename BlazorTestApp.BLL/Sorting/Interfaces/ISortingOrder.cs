using BlazorTestApp.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.BLL.Sorting.Interfaces
{
    public interface ISortingOrder
    {
        IEnumerable<OrderViewModel> Sort(string sortBy);
    }
}
