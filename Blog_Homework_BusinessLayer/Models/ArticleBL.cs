using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Homework_BusinessLayer.Models
{
    public class ArticleBL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public AuthorBL Author { get; set; }
        public CategoryBL Category { get; set; }
    }
}
