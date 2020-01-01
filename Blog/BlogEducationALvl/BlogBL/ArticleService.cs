using System.Collections.Generic;
using AutoMapper;
using BlogBL.BLModels;
using BlogDAL.Entities;
using BlogDAL.Repository;

namespace BlogBL
{
    public interface IArticleService : IGenereicService<ArticleBL>
    {

    }


    public class ArticleService : GenericService<ArticleBL, Article>, IArticleService
    {
        private readonly IMapper _mapper;
        public ArticleService(IGenericRepository<Article> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        public override ArticleBL Map(Article model)
        {
            return _mapper.Map<ArticleBL>(model);
            // TODO : use mapper 
            //return new ArticleBL()
            //{
            //    AuthorId = model.AuthorId,
            //    Body = model.Body,
            //    Image = model.Image,
            //    IsActive = model.IsActive,
            //    SubTitle = model.SubTitle,
            //    Title = model.Title,
            //    Date = model.Date,
            //    Id = model.Id
            //};
        }

        public override Article Map(ArticleBL model)
        {
            return _mapper.Map<Article>(model);
        }

        public override IEnumerable<ArticleBL> Map(IList<Article> entitiesList)
        {
            return _mapper.Map<IEnumerable<ArticleBL>>(entitiesList);
        }

        public override IEnumerable<Article> Map(IList<ArticleBL> entitiesList)
        {
            return _mapper.Map<IEnumerable<Article>>(entitiesList);
        }
    }
}
