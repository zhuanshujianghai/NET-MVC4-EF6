using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CommonFrame.Web.App_Start
{
    public class AutoFacConfig
    {
        /// <summary>
        ///  负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象的创建
        ///  负责创建MVC控制器类的对象(调用控制器中的有参构造函数),接管DefaultControllerFactory的工作
        /// </summary>
        public static void Register()
        {
            #region 逐个注册方法
            ////创建autofac管理注册类的容器实例
            //var builder = new ContainerBuilder();
            ////下面就需要为这个容器注册它可以管理的类型
            ////builder的Register方法可以通过多种方式注册类型,之前在控制台程序里面也演示了好几种方式了。
            //builder.RegisterType<People>().As<IPeople>();

            ////builder.RegisterType<DefaultController>().InstancePerDependency();
            ////使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            ////生成具体的实例
            //var container = builder.Build();
            ////下面就是使用MVC的扩展 更改了MVC中的注入方式.
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion

            #region 批量注册方法

            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();

            #region 一种注册方式
            //告诉autofac框架，将来要创建的控制器类存放在哪个程序集（CommonFrame.Web)
            Assembly controllerAss = Assembly.Load("CommonFrame.Web");
            builder.RegisterControllers(controllerAss).PropertiesAutowired();//支持构造方式和属性方式方式注入，不加PropertiesAutowired则只支持构造方式

            //告诉autofac框架注册Service层所在程序集中的所有类的对象实例到IService层所在程序集中的所有类的对象实例
            Assembly iserAss = Assembly.Load("CommonFrame.IService");
            Assembly serAss = Assembly.Load("CommonFrame.Service");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterAssemblyTypes(iserAss, serAss).AsImplementedInterfaces().PropertiesAutowired();//支持构造方式注入和属性方式注入，不加PropertiesAutowired则只支持构造方式

            //告诉autofac框架注册Repository层所在程序集中的所有类的对象实例到IRepository层所在程序集中的所有类的对象实例
            Assembly irepAss = Assembly.Load("CommonFrame.IRepository");
            Assembly repAss = Assembly.Load("CommonFrame.Repository");
            //创建serAss中的所有类的instance以此类的实现接口存储
            builder.RegisterAssemblyTypes(irepAss, repAss).AsImplementedInterfaces().PropertiesAutowired();//支持构造方式注入和属性方式注入，不加PropertiesAutowired则只支持构造方式
            #endregion

            #region 另一种注册方式
            ////如需加载实现的程序集，将dll拷贝到bin目录下即可，不用引用dll
            //var iServices = Assembly.Load("IocAufoFac.IServices");
            //var services = Assembly.Load("IocAufoFac.Services");
            //var iRepository = Assembly.Load("IocAufoFac.IRepository");
            //var repository = Assembly.Load("IocAufoFac.Repository");

            ////根据名称约定（服务层的接口和实现均以Services结尾），实现服务接口和服务实现的依赖
            //builder.RegisterAssemblyTypes(iServices, services)
            //  .Where(t => t.Name.EndsWith("Services"))
            //  .AsImplementedInterfaces();

            ////根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            //builder.RegisterAssemblyTypes(iRepository, repository)
            //  .Where(t => t.Name.EndsWith("Repository"))
            //  .AsImplementedInterfaces();
            #endregion

            //创建一个Autofac的容器
            var container = builder.Build();
            //将MVC的控制器对象实例 交由autofac来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            #endregion
        }
    }
}