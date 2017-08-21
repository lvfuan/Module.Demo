using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMvcPager.Models
{
    public class PagerDemo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string CreateUser { get; set; }
    }
}