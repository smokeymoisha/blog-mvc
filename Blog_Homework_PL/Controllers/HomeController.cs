using AutoMapper;
using Blog_Homework_BusinessLayer;
using Blog_Homework_BusinessLayer.Models;
using Blog_Homework_PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Homework_PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogManager _blogManager;
        private readonly Mapper _mapper;

        public HomeController()
        {
            _blogManager = new BlogManager();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleViewModel, ArticleBL>();
                cfg.CreateMap<AuthorViewModel, AuthorBL>();
                cfg.CreateMap<CategoryViewModel, CategoryBL>();
                cfg.CreateMap<ArticleBL, ArticleViewModel>();
                cfg.CreateMap<AuthorBL, AuthorViewModel>();
                cfg.CreateMap<CategoryBL, CategoryViewModel>();
            });

            _mapper = new Mapper(config);
        }

        public ActionResult Index()
        {
            var articleList = _blogManager.GetAllArticles();

            var result = _mapper.Map<IEnumerable<ArticleViewModel>>(articleList);

            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleViewModel article)
        {
            var result = _mapper.Map<ArticleViewModel, ArticleBL>(article);

            _blogManager.CreateArticle(result);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var article = _blogManager.GetArticleById(id);

            var result = _mapper.Map<ArticleBL, ArticleViewModel>(article);

            return View(result);
        }

        public ActionResult Edit(int id)
        {
            var article = _blogManager.GetArticleById(id);

            var result = _mapper.Map<ArticleBL, ArticleViewModel>(article);

            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(ArticleViewModel article)
        {
            var result = _mapper.Map<ArticleViewModel, ArticleBL>(article);

            _blogManager.EditArticle(result);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var article = _blogManager.GetArticleById(id);

            var result = _mapper.Map<ArticleBL, ArticleViewModel>(article);

            return View(result);
        }

        [HttpPost]
        public ActionResult Delete(ArticleViewModel article)
        {
            var result = _mapper.Map<ArticleViewModel, ArticleBL>(article);

            int id = result.Id;

            _blogManager.DeleteArticle(id);

            return RedirectToAction("Index");
        }
    }
}