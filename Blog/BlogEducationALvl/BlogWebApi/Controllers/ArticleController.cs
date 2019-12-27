using AutoMapper;
using BlogBL;
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

        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }
        // GET: api/Article
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Article/5
        public ArticleModel Get(int id)
        {
            var articleBL = _articleService.FindById(id);
            var article = _mapper.Map<ArticleModel>(articleBL);
            return article;
        }

        // POST: api/Article
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Article/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Article/5
        public void Delete(int id)
        {
        }
    }
}
