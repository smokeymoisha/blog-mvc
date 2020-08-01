using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_BusinessLayer.Models
{
    public class CategoryBL
    {
        public CategoryBL()
        {
            Articles = new List<ArticleBL>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<ArticleBL> Articles { get; set; }
    }
}
