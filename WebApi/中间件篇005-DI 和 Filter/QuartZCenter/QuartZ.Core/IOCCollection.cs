using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Quartz.Impl;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;

namespace QuartZ.Core
{
    public class IOCCollection
    {
        /// <summary>
        /// 私有类
        /// </summary>
        private IOCCollection()
        {

        }

        #region Field Area
        private static ContainerBuilder _builder  = new ContainerBuilder();
        private static IContainer _container;
        private static string[] _otherAssembly;
        private static List<Type> _types = new List<Type>();
        private static Dictionary<Type, Type> _dicTypes = new Dictionary<Type, Type>();
        /// <summary>
        /// 配置
        /// </summary>
        public IConfigurationRoot Config { get; set; }
        /// <summary>
        /// Provider
        /// </summary>
        private static IServiceProvider _serviceProvider { get; set; }

        /// <summary>
        /// IOC容器
        /// </summary>
        public IServiceCollection RDYServiceCollection { get; private set; } = new ServiceCollection();
        public static readonly object obj = new object();
        
        private static IOCCollection _instance;
        public static IOCCollection Instance
        {
            get 
            {
                if (_instance is null)
                {
                    lock (obj)
                    {
                        if (_instance is null)
                        {
                            _instance = new IOCCollection();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion

        #region Configuration
        /// <summary>
        /// 配置文件加载
        /// </summary>
        public IOCCollection AddConfigurationSetting()
        {
            return AddConfigurationSetting("appsettings.json", optional: false, reloadOnChange: true);
        }
        /// <summary>
        /// 配置文件加载
        /// </summary>
        /// <param name="jsonFileName"></param>
        /// <param name="optional"></param>
        /// <param name="reloadOnChange"></param>
        public IOCCollection AddConfigurationSetting(string jsonFileName, bool optional = false, bool reloadOnChange = true)
            => AddConfigurationSetting(() =>
            {
                var builder = new ConfigurationBuilder()
                           .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                           .AddJsonFile(jsonFileName, optional: optional, reloadOnChange: reloadOnChange);
                return builder.Build();
            });
        /// <summary>
        /// 配置文件扩展
        /// </summary>
        /// <param name="configRoot"></param>
        /// <returns></returns>
        public IOCCollection AddConfigurationSetting(Func<IConfigurationRoot> configRoot)
        {
            Config = configRoot();
            return this;
        }
        #endregion

        #region Mul Register
        /// <summary>
        /// 注册程序集
        /// </summary>
        /// <param name="assemblies">程序集名称的集合</param>
        public static void Register(params string[] assemblies)
        {
            _otherAssembly = assemblies;
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="types"></param>
        public static void Register(params Type[] types)
        {
            _types.AddRange(types.ToList());
        }
        /// <summary>
        /// 注册程序集。
        /// </summary>
        /// <param name="implementationAssemblyName"></param>
        /// <param name="interfaceAssemblyName"></param>
        public static void Register(string implementationAssemblyName, string interfaceAssemblyName)
        {
            var implementationAssembly = Assembly.Load(implementationAssemblyName);
            var interfaceAssembly = Assembly.Load(interfaceAssemblyName);
            var implementationTypes =
                implementationAssembly.DefinedTypes.Where(t =>
                    t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsNested);
            foreach (var type in implementationTypes)
            {
                var interfaceTypeName = interfaceAssemblyName + ".I" + type.Name;
                var interfaceType = interfaceAssembly.GetType(interfaceTypeName);
                if (interfaceType.IsAssignableFrom(type))
                {
                    _dicTypes.Add(interfaceType, type);
                }
            }
        }
        #endregion

        #region Register

        ///// <summary>
        ///// 注册
        ///// </summary>
        ///// <typeparam name="TInterface"></typeparam>
        ///// <typeparam name="TImplementation"></typeparam>
        ////public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
        ////{
        ////    _dicTypes.Add(typeof(TInterface), typeof(TImplementation));
        ////}
        ///// <summary>
        ///// 注册一个单例实体
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="instance"></param>
        //public void AddSingleton<T>() where T : class
        //{
        //    _builder.RegisterType<T>().SingleInstance();
        //}

        ///// <summary>
        ///// 注册一个单例实体
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="IT">接口</typeparam>
        ///// <param name="instance"></param>
        //public void AddSingleton<IT, T>() where T : IT
        //{
        //    _builder.RegisterType<T>().As<IT>().SingleInstance();
        //}
        ///// <summary>
        ///// 作用域注册
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="instance"></param>
        //public void AddScoped<T>() where T : class
        //{
        //    _builder.RegisterType<T>().InstancePerLifetimeScope();
        //}
        ///// <summary>
        ///// 作用域注册
        ///// </summary>
        ///// <typeparam name="IT">接口</typeparam>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="instance"></param>
        //public void AddScoped<IT, T>() where T : IT
        //{
        //    _builder.RegisterType<T>().As<IT>().InstancePerLifetimeScope();
        //}
        ///// <summary>
        ///// 瞬态注册
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="instance"></param>
        //public void AddTransient<T>() where T : class
        //{
        //    _builder.RegisterType<T>().InstancePerDependency();
        //}
        ///// <summary>
        ///// 瞬态注册
        ///// </summary>
        ///// <typeparam name="IT"></typeparam>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="instance"></param>
        //public void AddTransient<IT, T>() where T : class, IT where IT : class
        //{
        //    _builder.RegisterType<T>().As<IT>().InstancePerDependency();
        //}
        #endregion

        #region Autofac Instance Get

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <returns></returns>
        //public static T Resolve<T>()
        //{
        //    return _container.Resolve<T>();
        //}

        //public static T Resolve<T>(params Parameter[] parameters)
        //{
        //    return _container.Resolve<T>(parameters);
        //}
        //public static object Resolve(Type targetType)
        //{
        //    return _container.Resolve(targetType);
        //}
        //public static object Resolve(Type targetType, params Parameter[] parameters)
        //{
        //    return _container.Resolve(targetType, parameters);
        //}
        #endregion

        #region Instance Get 
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
            => _serviceProvider.GetService<T>();

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetServices<T>()
            => GetService<T>();
        #endregion

        #region DI For StartUp
        public IOCCollection AddDependencyInjection(Action<IServiceCollection> service)
        {
            service(RDYServiceCollection);
            return this;
        }
        #endregion

        #region Start Run Search Dependency Injection
        /// <summary>
        /// 构建IOC容器
        /// </summary>
        private IServiceProvider Build(IServiceCollection services)
        {
            if (_otherAssembly != null)
            {
                foreach (var item in _otherAssembly)
                {
                    _builder.RegisterAssemblyTypes(Assembly.Load(item));
                }
            }

            if (_types != null)
            {
                foreach (var type in _types)
                {
                    _builder.RegisterType(type);
                }
            }

            if (_dicTypes != null)
            {
                foreach (var dicType in _dicTypes)
                {
                    _builder.RegisterType(dicType.Value).As(dicType.Key);
                }
            }
            var compilationLibrary = DependencyContext.Default
                                       .CompileLibraries
                                       .Where(x => !x.Serviceable && x.Type == "project")
                                       .ToList();
            List<Assembly> assemblyList1 = new List<Assembly>();
            foreach (var _compilation in compilationLibrary)
            {
                try
                {
                    assemblyList1.Add(System.Runtime.Loader.AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(_compilation.Name)));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(_compilation.Name + ex.Message);
                }
            }
            Type singletonType = typeof(IDISingleton);
            Type scopeType = typeof(IDIScoped);
            Type transientType = typeof(IDITransient);

            _builder.RegisterAssemblyTypes(assemblyList1.ToArray())
            .Where(type => singletonType.IsAssignableFrom(type) && !type.IsAbstract)
            .AsSelf().AsImplementedInterfaces().SingleInstance();

            _builder.RegisterAssemblyTypes(assemblyList1.ToArray())
            .Where(type => scopeType.IsAssignableFrom(type) && !type.IsAbstract)
            .AsSelf().AsImplementedInterfaces().InstancePerLifetimeScope();

            _builder.RegisterAssemblyTypes(assemblyList1.ToArray())
            .Where(type => transientType.IsAssignableFrom(type) && !type.IsAbstract)
            .AsSelf().AsImplementedInterfaces().InstancePerDependency();

            services.AddSingleton<StdSchedulerFactory>();

            _builder.Populate(services);
            _container = _builder.Build();
            return new AutofacServiceProvider(_container);
        }
        /// <summary>
        /// RunIoc
        /// </summary>
        public IOCCollection RunIOC() => RunIOC(ioc => _serviceProvider = Build(RDYServiceCollection));

        /// <summary>
        /// 自定义启动运行IOC
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public IOCCollection RunIOC(Action<IOCCollection> action)
        {
            action(this);
            return this;
        }
        #endregion

    }

}
