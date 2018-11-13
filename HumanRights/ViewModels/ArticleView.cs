using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HumanRights.Models;

namespace HumanRights.ViewModels
{
    public class ArticleView
    {
        public Article Article { get; set; }
        public int ArticlesReviewed { get; set; }
        public int TotalArticles { get; set; }
    }
}