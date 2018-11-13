using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HumanRights.Models;
using HumanRights.ViewModels;

namespace HumanRights.Controllers
{        
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {

            var totalArticles = _context.Articles.Count();
            var articlesReviewed = _context.Articles.Where(p => p.IsViolation != null).Count();

            if (articlesReviewed == 0)
                return View("/Error");

            var article = _context.Articles.FirstOrDefault(p => p.IsViolation == null &&
                                                              !(p.IsBeingRead));

            var articleView = new ArticleView { Article = article,
                                                ArticlesReviewed = articlesReviewed,
                                                TotalArticles = totalArticles };

            article.IsBeingRead = true;
            _context.SaveChanges();

            return View(articleView);
        }

        public ActionResult Error()
        {
            return View();
        }

        public void SaveChanges(int id)
        {
            var article = _context.Articles.FirstOrDefault(p => p.Id == id);

            article.IsBeingRead = false;
            _context.SaveChanges();
        }

        [HttpPost]
        public ActionResult Submit(ArticleView articleView)
        {
            var article = _context.Articles.FirstOrDefault(p => p.Id == articleView.Article.Id);

            article.IsViolation = articleView.Article.IsViolation;
            article.IsBeingRead = false;
            article.Comment = articleView.Article.Comment;

            _context.SaveChanges();

            return RedirectToAction("/Index");
        }
    }
}