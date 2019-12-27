using BlogDAL.Repository;
using LightInject;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBL
{
    public static class BLLightInjectCongiguration
    {
        public static ServiceContainer Congiguration(ServiceContainer container)
        {
            container.Register<IDatabase>(factory => new Database("DBBLOG"));
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return container;
        }
    }
}
