using AutoMapper;
using BlogBL;
using BlogBL.BLModels;
using BlogWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogWebApi.Controllers
{
    public class ArticleController : ApiController
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;

        public ArticleController()
        {

        }
        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        // GET: api/Article
        public IEnumerable<ArticleModel> Get()
        {
            var allArticlesBL = _articleService.GetAll();
            ICollection<ArticleModel> allArticleView = new List<ArticleModel>();
            foreach (var articleBL in allArticlesBL)
            {
                var articleModel = _mapper.Map<ArticleModel>(articleBL);
                allArticleView.Add(articleModel);
            }
            return allArticleView;
        }

        // GET: api/Article/5
        public ArticleModel Get(int id)
        {
            var articleBL = _articleService.FindById(id);
            var article = _mapper.Map<ArticleModel>(articleBL);
            return article;
        }

        // POST: api/Article
        [HttpPost]
        public void Post([FromBody]ArticleModel newArticle)
        {
            var newBLArticle = _mapper.Map<ArticleBL>(newArticle);
            _articleService.AddItem(newBLArticle);
        }

        // PUT: api/Article/5
        [HttpPut]
        public void Put(int id, [FromBody]ArticleModel editedArticle)
        {
            if (id==editedArticle.Id)
            {
                var editedBLArticle = _mapper.Map<ArticleBL>(editedArticle);
                _articleService.Update(editedBLArticle);
            }
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
            var articleToDeleteBL = _articleService.FindById(id);
            if (articleToDeleteBL!=null)
            {
                _articleService.Delete(articleToDeleteBL);
            }
        }
    }
}
