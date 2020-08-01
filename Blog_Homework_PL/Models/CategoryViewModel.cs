using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_PL.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            Articles = new List<ArticleViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<ArticleViewModel> Articles { get; set; }
    }
}
