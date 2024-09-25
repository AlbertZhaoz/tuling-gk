using Autofac;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using SqlSugar.IOC;
using VOL.Core.CacheManager;
using VOL.Core.Configuration;
using VOL.Core.Const;
using VOL.Core.Dapper;
using VOL.Core.DBManager;
using VOL.Core.EFDbContext;
using VOL.Core.Enums;
using VOL.Core.Extensions.AutofacManager;
using VOL.Core.ManageUser;
using VOL.Core.ObjectActionValidator;
using VOL.Core.Services;
using SqlSugar;
using ICacheService = VOL.Core.CacheManager.ICacheService;
using System.Configuration;

namespace VOL.Core.Extensions
{
    public static class AutofacContainerModuleExtension
    {
        public static IServiceCollection AddModuleByCollection(this IServiceCollection services,
            IConfiguration configuration)
        {
            // 自动激活 HSL
            HslCommunication.Authorization.SetAuthorizationCode("66634f11-68dc-45d5-9638-fccb9f6b8fed");

            //初始化配置文件
            AppSetting.Init(services, configuration);

            //启用缓存
            if (AppSetting.UseRedis)
            {
                services.AddSingleton<ICacheService, RedisCacheService>();
            }
            else
            {
                services.AddSingleton<ICacheService, MemoryCacheService>();
            }

            return services;
        }

        //  private static bool _isMysql = false;
        public static IServiceCollection AddModule(this IServiceCollection services, ContainerBuilder builder, IConfiguration configuration)
        {
            // 自动激活 HSL
            HslCommunication.Authorization.SetAuthorizationCode("66634f11-68dc-45d5-9638-fccb9f6b8fed");

            //services.AddSession();
            //services.AddMemoryCache();
            //初始化配置文件
            AppSetting.Init(services, configuration);
            Type baseType = typeof(IDependency);
            var compilationLibrary = DependencyContext.Default
                .RuntimeLibraries
                .Where(x => !x.Serviceable
                && x.Type == "project")
                .ToList();
            var count1 = compilationLibrary.Count;
            List<Assembly> assemblyList = new List<Assembly>();

            foreach (var _compilation in compilationLibrary)
            {
                try
                {
                    assemblyList.Add(AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(_compilation.Name)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(_compilation.Name + ex.Message);
                }
            }
            builder.RegisterAssemblyTypes(assemblyList.ToArray())
             .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
             .AsSelf().AsImplementedInterfaces()
             .InstancePerLifetimeScope();
            builder.RegisterType<UserContext>().InstancePerLifetimeScope();
            builder.RegisterType<ActionObserver>().InstancePerLifetimeScope();
            //model校验结果
            builder.RegisterType<ObjectModelValidatorState>().InstancePerLifetimeScope();
            string connectionString = DBServerProvider.GetConnectionString(null);

            if (AppSetting.UseCoreStorage)
            {
                if (DBType.Name == DbCurrentType.MySql.ToString())
                {
                    //2020.03.31增加dapper对mysql字段Guid映射
                    SqlMapper.AddTypeHandler(new DapperParseGuidTypeHandler());
                    SqlMapper.RemoveTypeMap(typeof(Guid?));

                    //services.AddDbContext<VOLContext>();
                    //mysql8.x的版本使用Pomelo.EntityFrameworkCore.MySql 3.1会产生异常，需要在字符串连接上添加allowPublicKeyRetrieval=true
                    services.AddDbContextPool<VOLContext>(optionsBuilder => { optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 11))); }, 64);
                }
                else if (DBType.Name == DbCurrentType.PgSql.ToString())
                {
                    services.AddDbContextPool<VOLContext>(optionsBuilder => { optionsBuilder.UseNpgsql(connectionString); }, 64);
                }
                else
                {
                    services.AddDbContextPool<VOLContext>(optionsBuilder => { optionsBuilder.UseSqlServer(connectionString); }, 64);
                }

                if (AppSetting.SqlSugarConnections.Count > 0)
                {
                    var iocList = new List<IocConfig>();

                    foreach (var sqlConnection in AppSetting.SqlSugarConnections)
                    {
                        iocList.Add(new IocConfig()
                        {
                            ConfigId = sqlConnection.ConfigId,
                            ConnectionString = sqlConnection.ConnectionString,
                            DbType = sqlConnection.DBType,
                            IsAutoCloseConnection = sqlConnection.IsAutoCloseConnection,
                        });
                    }

                    services.AddSqlSugar(iocList);

                    ////配置数据库拦截
                    //services.ConfigurationSugar(db =>
                    //{
                    //    iocList.ForEach(q =>
                    //    {
                    //        if (q.ConfigId == "Default")
                    //        {
                    //            db.GetConnection("Default").Aop.OnLogExecuting = (sql, pars) =>
                    //            {
                    //                if (sql.ToUpper().Contains("ALBERT_DATAFIRST") ||
                    //                    sql.ToUpper().Contains("ALBERT_DATASECOND")||
                    //                    sql.ToUpper().Contains("ALBERT_RFID"))
                    //                {
                    //                    //Console.WriteLine($"\r\n{UtilMethods.GetNativeSql(sql, pars)}\r\n");
                    //                    Console.WriteLine($"\r\n{UtilMethods.GetNativeSql(string.Empty, pars)}\r\n");
                    //                }
                    //            };
                    //        }
                    //    });
                    //    //设置更多连接参数
                    //    //db.CurrentConnectionConfig.XXXX=XXXX
                    //    //db.CurrentConnectionConfig.MoreSettings=new ConnMoreSettings(){}
                    //    //二级缓存设置
                    //    //db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices()
                    //    //{
                    //    // DataInfoCacheService = myCache //配置我们创建的缓存类
                    //    //}
                    //    //读写分离设置
                    //    //laveConnectionConfigs = new List<SlaveConnectionConfig>(){...}

                    //    /*多租户注意*/
                    //    //单库是db.CurrentConnectionConfig 
                    //    //多租户需要db.GetConnection(configId).CurrentConnectionConfig 
                    //});
                }
            }
            
            //启用缓存
            if (AppSetting.UseRedis)
            {
                builder.RegisterType<RedisCacheService>().As<ICacheService>().SingleInstance();
            }
            else
            {
                builder.RegisterType<MemoryCacheService>().As<ICacheService>().SingleInstance();
            }

            //kafka注入
            //if (AppSetting.Kafka.UseConsumer)
            //    builder.RegisterType<KafkaConsumer<string, string>>().As<IKafkaConsumer<string, string>>().SingleInstance();
            //if (AppSetting.Kafka.UseProducer)
            //    builder.RegisterType<KafkaProducer<string, string>>().As<IKafkaProducer<string, string>>().SingleInstance();
            return services;
        }

    }
}
