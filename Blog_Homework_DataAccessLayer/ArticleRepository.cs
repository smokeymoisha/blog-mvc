using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;
using Blog_Homework_DataAccessLayer.Models;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_DataAccessLayer
{
    public class ArticleRepository : IRepository<Article>
    {
        public void Create(Article article)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Articles.Add(article);

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new BlogContext())
            {
                var articleToRemove = ctx.Articles.FirstOrDefault(art => art.Id == id);

                ctx.Articles.Remove(articleToRemove);

                ctx.SaveChanges();
            }
        }

        public void Edit(Article article)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Articles.AddOrUpdate(article);

                ctx.SaveChanges();
            }
        }

        public IList<Article> GetAll()
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Articles.Include(art => art.Author).Include(art => art.Category).ToList();
            }
        }

        public Article GetById(int id)
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Articles.Include(art => art.Author).Include(art => art.Category).FirstOrDefault(art => art.Id == id);
            }
        }
    }
}
