using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpyou.net.cn.DB.Models
{
    public class MenuModel:BaseModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ParentUrl { get; set; }
        public int Level { get; set; }
    }
}
