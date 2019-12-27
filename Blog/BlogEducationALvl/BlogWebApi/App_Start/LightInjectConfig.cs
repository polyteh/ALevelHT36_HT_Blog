using AutoMapper;
using BlogBL;
using LightInject;
using LightInject.Mvc;
using LightInject.WebApi;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace BlogWebApi.App_Start
{
    public class LightInjectConfig
    {
        public static void Congigurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new WebAutomapperProfile(), new BLAutomapperProfile() }));

            container.Register(c => config.CreateMapper());

            container = BLLightInjectCongiguration.Congiguration(container);

            container.Register<IArticleService, ArticleService>();
            //var resolver = new LightInjectWebApiDependencyResolver(container);             
            //DependencyResolver.SetResolver(new LightInjectMvcDependencyResolver(container));
            container.EnableMvc();

        }
    }
}