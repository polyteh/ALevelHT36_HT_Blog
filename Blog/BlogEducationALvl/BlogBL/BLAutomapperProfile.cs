using AutoMapper;
using BlogBL.BLModels;
using BlogDAL.Entities;
using System.Collections.Generic;

namespace BlogBL
{
    public class BLAutomapperProfile : Profile
    {
        public BLAutomapperProfile()
        {
            CreateMap<ArticleBL, Article>().ReverseMap();
            CreateMap<CommentBL, Comment>().ReverseMap();
     

        }
    }
        
}
