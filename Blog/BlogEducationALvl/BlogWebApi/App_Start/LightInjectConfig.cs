using AutoMapper;
using BlogBL;
using LightInject;
using LightInject.Mvc;
using LightInject.WebApi;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

namespace BlogWebApi.App_Start
{
    public class LightInjectConfig
    {
        public static void Congigurate()
        {
            var container = new ServiceContainer();//mvc
            container.RegisterApiControllers(Assembly.GetExecutingAssembly());
           // container.RegisterControllers(Assembly.GetExecutingAssembly());//rem

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLightInjectCongiguration.Congiguration(container);

            container.Register<IArticleService, ArticleService>();
            //var resolver = new LightInjectWebApiDependencyResolver(container);             
            //DependencyResolver.SetResolver(new LightInjectMvcDependencyResolver(container));

            //container.EnableMvc();//rem
            container.EnablePerWebRequestScope();
            container.EnableWebApi(GlobalConfiguration.Configuration);

        }
    }
}