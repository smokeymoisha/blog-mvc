using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_DataAccessLayer.Models
{
    public class Category
    {
        public Category()
        {
            Articles = new List<Article>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Article> Articles { get; set; }
    }
}
