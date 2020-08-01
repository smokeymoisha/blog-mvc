using Blog_Homework_DataAccessLayer;
using Blog_Homework_DataAccessLayer.Models;
using Blog_Homework_BusinessLayer.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_BusinessLayer
{
    public class BlogManager
    {
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly Mapper _mapper;

        public BlogManager()
        {
            _articleRepository = new ArticleRepository();
            _authorRepository = new AuthorRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleBL>();
                cfg.CreateMap<Author, AuthorBL>();
                cfg.CreateMap<Category, CategoryBL>();
                cfg.CreateMap<ArticleBL, Article>();
                cfg.CreateMap<AuthorBL, Author>();
                cfg.CreateMap<CategoryBL, Category>();
            });

            _mapper = new Mapper(config);
        }

        public IList<ArticleBL> GetAllArticles()
        {
            var articleList = _articleRepository.GetAll();

            var result = _mapper.Map<IList<ArticleBL>>(articleList);

            return result;
        }

        public void CreateArticle(ArticleBL article)
        {
            var result = _mapper.Map<ArticleBL, Article>(article);

            _articleRepository.Create(result);
        }

        public void DeleteArticle(int id)
        {
            _articleRepository.Delete(id);
        }

        public void EditArticle(ArticleBL article)
        {
            var result = _mapper.Map<ArticleBL, Article>(article);

            _articleRepository.Edit(result);
        }

        public ArticleBL GetArticleById(int id)
        {
            var article = _articleRepository.GetById(id);

            var result = _mapper.Map<Article, ArticleBL>(article);

            return result;
        }

        public void CreateAuthor(AuthorBL author)
        {
            var result = _mapper.Map<AuthorBL, Author>(author);

            _authorRepository.Create(result);
        }

        public void DeleteAuthor(int id)
        {
            _articleRepository.Delete(id);
        }

        public void EditAuthor(AuthorBL author)
        {
            var result = _mapper.Map<AuthorBL, Author>(author);

            _authorRepository.Edit(result);
        }

        public IList<AuthorBL> GetAllAuthors()
        {
            var authorList = _authorRepository.GetAll();

            var result = _mapper.Map<IList<AuthorBL>>(authorList);

            return result;
        }

        public AuthorBL GetById(int id)
        {
            var author = _authorRepository.GetById(id);

            var result = _mapper.Map<Author, AuthorBL>(author);

            return result;
        }
    }
}
