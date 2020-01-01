using AutoMapper;
using BlogBL;
using BlogBL.BLModels;
using BlogEducationALvl.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogEducationALvl.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IMapper _mapper;
        public ArticleController(IArticleService articleService, IMapper mapper)
        {
            _articleService = articleService;
            _mapper = mapper;
        }

        // GET: Article
        public ActionResult Index()
        {
            
            var listBLArticle = _articleService.GetAll();
            var articles = _mapper.Map<IEnumerable<ArticleModel>>(listBLArticle);          
            return View(articles);
        }

        // GET: Article/Details/5
 
        public ActionResult Details(int id)
        {
            var articleBL =  _articleService.FindById(id);
            var article = _mapper.Map<ArticleModel>(articleBL);
            //ArticleModel article = new ArticleModel
            //{
            //    AuthorId = articleBL.AuthorId,
            //    Body = articleBL.Body,
            //    Image = articleBL.Image,
            //    IsActive = articleBL.IsActive,
            //    SubTitle = articleBL.SubTitle,
            //    Title = articleBL.Title,
            //    Date = articleBL.Date,
            //    Id = articleBL.Id
            //};

            return View(article);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(ArticleModel newArticle)
        {
            //try
            //{
            //    // TODO: Add insert logic here
            //    var newBLArticle = _mapper.Map<ArticleBL>(newArticle);
            //    _articleService.AddItem(newBLArticle);
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            if (ModelState.IsValid) {
                var newBLArticle = _mapper.Map<ArticleBL>(newArticle);
                _articleService.AddItem(newBLArticle);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Not Valid";
                return View(newArticle);
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            var articleBL = _articleService.FindById(id);
            var article = _mapper.Map<ArticleModel>(articleBL);
            return View(article);
        }

        // POST: Article/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(ArticleModel editedArticle)
        {
            try
            {
                var editedBLArticle = _mapper.Map<ArticleBL>(editedArticle);
                _articleService.Update(editedBLArticle);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            var articleBL = _articleService.FindById(id);
            var articleToDelete = _mapper.Map<ArticleModel>(articleBL);
            return View(articleToDelete);
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(ArticleModel deletedArticle)
        {
            try
            {
                var articleDeleteBL = _articleService.FindById(deletedArticle.Id);
                if (articleDeleteBL!=null)
                {
                    _articleService.Delete(articleDeleteBL);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
