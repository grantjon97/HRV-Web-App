using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanRights.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool? IsViolation { get; set; } = null;
        public bool IsBeingRead { get; set; }
        public string Comment { get; set; }
    }
}