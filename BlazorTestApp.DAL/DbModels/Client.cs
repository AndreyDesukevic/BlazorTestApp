﻿using BlazorTestApp.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestApp.DAL.DbModels
{
    public class Client : BaseModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateCreate { get; set; }
        public ClientStatus ClientStatus { get; set; }
        public List<Order> Orders { get; set; }
        public string? Description { get; set; }
        public string NameUserMadeChange { get; set; }
        public User User { get; set; }  
       
    }
}
