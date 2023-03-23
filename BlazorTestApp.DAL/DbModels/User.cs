using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.DbModels
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }  
        public bool IsBlocked { get; set; }
    }
}
