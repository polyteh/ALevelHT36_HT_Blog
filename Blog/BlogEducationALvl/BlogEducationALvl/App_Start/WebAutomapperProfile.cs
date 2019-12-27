using AutoMapper;
using BlogBL.BLModels;
using BlogEducationALvl.Models;

namespace BlogEducationALvl.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<ArticleModel, ArticleBL>().ReverseMap();
        }
    }
}