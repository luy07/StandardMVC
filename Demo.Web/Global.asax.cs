using Autofac;
using Autofac.Integration.Mvc;
using Data.Seedwork;
using Demo.Data;
using Demo.Service;
using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Demo.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var timer = System.Diagnostics.Stopwatch.StartNew();
            SetDependencyResolver();
            timer.Stop();
            System.Diagnostics.Debug.WriteLine(string.Format("Execute SetDependencyResolver() elapsed：{0} ms !", timer.ElapsedMilliseconds));

            timer.Restart();
            //初始化数据库
            new YmtCS_DbInitializer().InitializeDatabase(new YmatouUnitOfWork());

              timer.Stop();
            System.Diagnostics.Debug.WriteLine(string.Format("InitializeDatabase() elapsed：{0} ms !", timer.ElapsedMilliseconds));

        }


        /// <summary>
        /// 依赖注入处理
        /// </summary>
        private void SetDependencyResolver()
        {
            var containerBuilder = new ContainerBuilder();

            var assembly1 = System.Reflection.Assembly.GetAssembly(typeof(IRepository<>));
            var assembly2 = System.Reflection.Assembly.GetAssembly(typeof(Repository<>));
            var assembly3 = System.Reflection.Assembly.GetAssembly(typeof(IService));

            containerBuilder.RegisterAssemblyTypes(new System.Reflection.Assembly[] { assembly1, assembly2, assembly3 });

            //containerBuilder.RegisterControllers()
            DependencyResolver.SetResolver(new AutofacDependencyResolver(containerBuilder.Build()));
        }





    }
}
