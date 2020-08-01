using Blog_Homework_DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_DataAccessLayer
{
    public class AuthorRepository : IRepository<Author>
    {
        public void Create(Author author)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Authors.Add(author);

                ctx.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new BlogContext())
            {
                var authorToRemove = ctx.Authors.FirstOrDefault(auth => auth.Id == id);

                ctx.Authors.Remove(authorToRemove);

                ctx.SaveChanges();
            }
        }

        public void Edit(Author author)
        {
            using (var ctx = new BlogContext())
            {
                ctx.Authors.AddOrUpdate(author);

                ctx.SaveChanges();
            }
        }

        public IList<Author> GetAll()
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Authors.Include(auth => auth.Articles).ToList();
            }
        }

        public Author GetById(int id)
        {
            using (var ctx = new BlogContext())
            {
                return ctx.Authors.Include(auth => auth.Articles).FirstOrDefault(auth => auth.Id == id);
            }
        }
    }
}
