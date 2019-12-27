using AutoMapper;
using BlogBL.BLModels;
using BlogWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogWebApi.App_Start
{
    public class WebAutomapperProfile : Profile
    {
        public WebAutomapperProfile()
        {
            CreateMap<ArticleModel, ArticleBL>().ReverseMap();
        }
    }
}