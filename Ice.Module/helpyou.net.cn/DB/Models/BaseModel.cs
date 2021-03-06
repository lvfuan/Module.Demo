﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace helpyou.net.cn.DB.Models
{
    public class BaseModel
    {
        [Key]
        public int? Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public string CreateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public bool? State { get; set; }
    }
}
