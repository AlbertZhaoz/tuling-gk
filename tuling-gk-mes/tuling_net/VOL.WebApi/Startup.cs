using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CZGL.ProcessMetrics;
using DotNetify;
using DotNetify.Pulse;
using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Quartz;
using Quartz.Impl;
using Swashbuckle.AspNetCore.SwaggerGen;
using VOL.Core.Configuration;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions;
using VOL.Core.Filters;
using VOL.Core.HealthCheck;
using VOL.Core.HttpService;
using VOL.Core.Middleware;
using VOL.Core.ObjectActionValidator;
using VOL.Core.Quartz;
using VOL.WebApi.AutoMapperConfigs;
using VOL.WebApi.Controllers.Hubs;
using VOL.WebApi.DotNetify;

namespace VOL.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IServiceCollection Services { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 初始化模型验证配置
            services.UseMethodsModelParameters().UseMethodsGeneralParameters();
            services.AddSingleton<IObjectModelValidator>(new NullObjectModelValidator());
            Services = services;
            // services.Replace( ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            services.AddSession();
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ApiAuthorizeFilter));
                options.Filters.Add(typeof(ActionExecuteFilter));
                //  options.SuppressAsyncSuffixInActionNames = false;
            });

            services.AddControllers()
              .AddNewtonsoftJson(op =>
              {
                  op.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                  op.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
              });

            Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     SaveSigninToken = true,//保存token,后台验证token是否生效(重要)
                     ValidateIssuer = true,//是否验证Issuer
                     ValidateAudience = true,//是否验证Audience
                     ValidateLifetime = true,//是否验证失效时间
                     ValidateIssuerSigningKey = true,//是否验证SecurityKey
                     ValidAudience = AppSetting.Secret.Audience,//Audience
                     ValidIssuer = AppSetting.Secret.Issuer,//Issuer，这两项和前面签发jwt的设置一致
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSetting.Secret.JWT))
                 };
                 options.Events = new JwtBearerEvents()
                 {
                     OnChallenge = context =>
                     {
                         context.HandleResponse();
                         context.Response.Clear();
                         context.Response.ContentType = "application/json";
                         context.Response.StatusCode = 401;
                         context.Response.WriteAsync(new { message = "授权未通过", status = false, code = 401 }.Serialize());
                         return Task.CompletedTask;
                     }
                 };
             });
            //必须appsettings.json中配置
            string corsUrls = Configuration["CorsUrls"];
            if (string.IsNullOrEmpty(corsUrls))
            {
                throw new Exception("请配置跨请求的前端Url");
            }
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                        builder =>
                        {
                            builder.AllowAnyOrigin()
                           .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
                            .AllowAnyHeader().AllowAnyMethod();
                        });
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // 增加拦截日志中间件
            services.AddSingleton<LoggingMiddleware>();
            services.AddScoped<HttpChatGptService>(x => new HttpChatGptService(AppSetting.ChatGptInfo.ChatGptUrl,
                AppSetting.ChatGptInfo.ChatGptToken));
            services.AddControllers();
            // 增加健康监测（Api+数据库)
            services.AddHealthChecks().AddCheck<ApiHealthCheck>("ApiHealthCheck");
            services.AddHealthChecks().AddDbContextCheck<VOLContext>("DbHealthCheck");
            services.AddSwaggerGen(c =>
            {
                // 分为 2 份接口文档
                c.SwaggerDoc("v1", 
                    new OpenApiInfo { Title = "brother.mes interface doc", Version = "v1", Description = "brother.mes interface doc" });

                // 增加文档注释，要在项目属性里面配置生成 swagger.xml 文件路径
                var file = Path.Combine(AppContext.BaseDirectory,"swagger.xml");
                c.IncludeXmlComments(file,true);
                // 对 Action 名称进行排序
                c.OrderActionsBy(o=> o.RelativePath);
               
                var security = new Dictionary<string, IEnumerable<string>> { { AppSetting.Secret.Issuer, new string[] { } } };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT授权token前面需要加上字段Bearer与一个空格,如Bearer token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            })
              .AddControllers()
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
                options.SuppressMapClientErrors = true;
                options.ClientErrorMapping[404].Link =
                    "https://*/404";
            });
            services.AddSignalR();
            // 注册 DotNetify
            services.TryAddEnumerable(ServiceDescriptor.Singleton<IPulseDataProvider, DbMonitorProvider>());
            services.AddDotNetify();
            services.AddDotNetifyPulse();

            services.AddHttpClient();
            Services.AddTransient<HttpResultfulJob>();
            Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            Services.AddSingleton<Quartz.Spi.IJobFactory, IOCJobFactory>();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            Services.AddModule(builder, Configuration);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseQuartz(env);
            // 使用日志拦截中间件
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleWare>();
            app.UseStaticFiles().UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
            });
            app.UseDefaultFiles();
            app.Use(HttpRequestMiddleware.Context);

            //2021.06.27增加创建默认upload文件夹
            string _uploadPath = (env.ContentRootPath + "/Upload").ReplacePath();

            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"Upload")),
                //配置访问虚拟目录时文件夹别名
                RequestPath = "/Upload",
                OnPrepareResponse = (Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext staticFile) =>
                {
                    // 可以在此处读取请求的信息进行权限认证
                    //  staticFile.File
                    //  staticFile.Context.Response.StatusCode;
                }
            });
            // 配置 HttpContext
            app.UseStaticHttpContext();

            // 配置 Swagger 文档
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "brother.mes interface doc");
                c.RoutePrefix = "";
            });

            // 使用 dotnetify
            app.UseWebSockets();
            app.UseDotNetify();
            app.UseDotNetifyPulse(config=>config.UIPath = Directory.GetCurrentDirectory()+"\\pulse-ui");

            app.UseRouting();
            // UseCors,UseAuthenticationg两个位置的顺序很重要           
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHealthChecks("/health", options: new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    // 以 Json 形式输出所有的健康监测数据
                    var reportList = report.Entries.Select(x => new
                    {
                        Name = x.Key,
                        Description = x.Value.Description,
                        Duration  = x.Value.Duration,
                        // 将 Status 的状态码变为英文
                        Status = Enum.GetName(typeof(HealthStatus), x.Value.Status),
                    }) ;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(reportList));
                }
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // 配置SignalR
                if (AppSetting.UseSignalR)
                {
                    string corsUrls = Configuration["CorsUrls"];
                    endpoints.MapHub<HomePageMessageHub>("/message").RequireCors(t =>
                    t.WithOrigins(corsUrls.Split(',')).
                    AllowAnyMethod().
                    AllowAnyHeader().
                    AllowCredentials());
                }
                // 健康监测
                endpoints.ProcessMetrices("/metrics");
                // dotnetify 健康监测
                endpoints.MapHub<DotNetifyHub>("/dotnetify");
            });
        }

        /// <summary>
        /// 获取控制器对应的swagger分组值
        /// </summary>
        private string GetSwaggerGroupName(Type controller)
        {
            var groupName = controller.Name.Replace("Controller", "");
            var apiSetting = controller.GetCustomAttribute(typeof(ApiExplorerSettingsAttribute));
            if (apiSetting != null)
            {
                groupName = ((ApiExplorerSettingsAttribute)apiSetting).GroupName;

            }

            return groupName;
        }

        /// <summary>
        /// 获取所有的控制器
        /// </summary>
        private List<Type> GetControllers()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var contradistinction = asm.GetTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                .OrderBy(x => x.Name).ToList();
            return contradistinction;
        }
    }

    /// <summary>
    /// Swagger 注释帮助类
    /// </summary>
    public class SwaggerDocTag : IDocumentFilter
    {
        /// <summary>
        /// 添加附加注释
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //添加对应的控制器描述
            swaggerDoc.Tags = new List<OpenApiTag>
            {
                new OpenApiTag { Name = "Test", Description = "这是描述" },
            };
        }
    }
}
