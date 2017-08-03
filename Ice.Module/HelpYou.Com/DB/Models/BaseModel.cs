using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpYou.Com.DB.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public bool? State { get; set; }
    }
}
