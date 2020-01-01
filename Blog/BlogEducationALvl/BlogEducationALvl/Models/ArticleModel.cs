using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogEducationALvl.Models
{
    public class ArticleModel
    {
        //public Article()
        //{
        //    Comments = new List<Comment>()
        //}

        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter article title")]
        [Display(Name = "Article title")]
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        [Range(1, 100)]
        public int AuthorId { get; set; }
        //data format
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public List<CommentModel> Comments { get; set; }
    }
}