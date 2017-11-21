using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApplication.Business.Manager;
using WebApplication.Core.Interfaces.Business;
using WebApplication.Core.Interfaces.Repostories;
using WebApplication.Core.Interfaces.Shared;
using WebApplication.Core.Model;
using WebApplication.Data.Repositories;
using WebApplication.Data.Repositories.Shared;
using WebGrease.Css.Extensions;

namespace WebApplication.Web.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterFilterProvider();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))
                    || (typeof(IUnitOfWork).IsAssignableFrom(t) && !t.IsAbstract))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ManagerBase).Assembly)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            RegisterMapper(typeof(MvcApplication).Assembly, builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void RegisterMapper(Assembly assembly, ContainerBuilder builder)
        {
            var profiles = assembly
                .GetTypes()
                .Where(typeof(AutoMapper.Profile).IsAssignableFrom);

            var BusinessProfiles = typeof(WebApplication.Business.MapperProfile.UserProfile).Assembly
                .GetTypes()
                .Where(typeof(AutoMapper.Profile).IsAssignableFrom);


            builder.Register(context => new MapperConfiguration(cng =>
            {
                BusinessProfiles.ForEach(p => cng.AddProfile(p));
                profiles.ForEach(p => cng.AddProfile(p));
            }))
            .AsImplementedInterfaces()
            .SingleInstance();

            builder.RegisterType<Mapper>()
                .As<IMapper>()
                .InstancePerLifetimeScope();


        }
    }
}