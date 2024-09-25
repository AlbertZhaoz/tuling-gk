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
            // ��ʼ��ģ����֤����
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
                     SaveSigninToken = true,//����token,��̨��֤token�Ƿ���Ч(��Ҫ)
                     ValidateIssuer = true,//�Ƿ���֤Issuer
                     ValidateAudience = true,//�Ƿ���֤Audience
                     ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
                     ValidateIssuerSigningKey = true,//�Ƿ���֤SecurityKey
                     ValidAudience = AppSetting.Secret.Audience,//Audience
                     ValidIssuer = AppSetting.Secret.Issuer,//Issuer���������ǰ��ǩ��jwt������һ��
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
                         context.Response.WriteAsync(new { message = "��Ȩδͨ��", status = false, code = 401 }.Serialize());
                         return Task.CompletedTask;
                     }
                 };
             });
            //����appsettings.json������
            string corsUrls = Configuration["CorsUrls"];
            if (string.IsNullOrEmpty(corsUrls))
            {
                throw new Exception("�����ÿ������ǰ��Url");
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
            // ����������־�м��
            services.AddSingleton<LoggingMiddleware>();
            services.AddScoped<HttpChatGptService>(x => new HttpChatGptService(AppSetting.ChatGptInfo.ChatGptUrl,
                AppSetting.ChatGptInfo.ChatGptToken));
            services.AddControllers();
            // ���ӽ�����⣨Api+���ݿ�)
            services.AddHealthChecks().AddCheck<ApiHealthCheck>("ApiHealthCheck");
            services.AddHealthChecks().AddDbContextCheck<VOLContext>("DbHealthCheck");
            services.AddSwaggerGen(c =>
            {
                // ��Ϊ 2 �ݽӿ��ĵ�
                c.SwaggerDoc("v1", 
                    new OpenApiInfo { Title = "brother.mes interface doc", Version = "v1", Description = "brother.mes interface doc" });

                // �����ĵ�ע�ͣ�Ҫ����Ŀ���������������� swagger.xml �ļ�·��
                var file = Path.Combine(AppContext.BaseDirectory,"swagger.xml");
                c.IncludeXmlComments(file,true);
                // �� Action ���ƽ�������
                c.OrderActionsBy(o=> o.RelativePath);
               
                var security = new Dictionary<string, IEnumerable<string>> { { AppSetting.Secret.Issuer, new string[] { } } };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT��Ȩtokenǰ����Ҫ�����ֶ�Bearer��һ���ո�,��Bearer token",
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
            // ע�� DotNetify
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
            // ʹ����־�����м��
            app.UseMiddleware<LoggingMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleWare>();
            app.UseStaticFiles().UseStaticFiles(new StaticFileOptions
            {
                ServeUnknownFileTypes = true,
            });
            app.UseDefaultFiles();
            app.Use(HttpRequestMiddleware.Context);

            //2021.06.27���Ӵ���Ĭ��upload�ļ���
            string _uploadPath = (env.ContentRootPath + "/Upload").ReplacePath();

            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"Upload")),
                //���÷�������Ŀ¼ʱ�ļ��б���
                RequestPath = "/Upload",
                OnPrepareResponse = (Microsoft.AspNetCore.StaticFiles.StaticFileResponseContext staticFile) =>
                {
                    // �����ڴ˴���ȡ�������Ϣ����Ȩ����֤
                    //  staticFile.File
                    //  staticFile.Context.Response.StatusCode;
                }
            });
            // ���� HttpContext
            app.UseStaticHttpContext();

            // ���� Swagger �ĵ�
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "brother.mes interface doc");
                c.RoutePrefix = "";
            });

            // ʹ�� dotnetify
            app.UseWebSockets();
            app.UseDotNetify();
            app.UseDotNetifyPulse(config=>config.UIPath = Directory.GetCurrentDirectory()+"\\pulse-ui");

            app.UseRouting();
            // UseCors,UseAuthenticationg����λ�õ�˳�����Ҫ           
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHealthChecks("/health", options: new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    context.Response.ContentType = "application/json";
                    // �� Json ��ʽ������еĽ����������
                    var reportList = report.Entries.Select(x => new
                    {
                        Name = x.Key,
                        Description = x.Value.Description,
                        Duration  = x.Value.Duration,
                        // �� Status ��״̬���ΪӢ��
                        Status = Enum.GetName(typeof(HealthStatus), x.Value.Status),
                    }) ;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(reportList));
                }
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // ����SignalR
                if (AppSetting.UseSignalR)
                {
                    string corsUrls = Configuration["CorsUrls"];
                    endpoints.MapHub<HomePageMessageHub>("/message").RequireCors(t =>
                    t.WithOrigins(corsUrls.Split(',')).
                    AllowAnyMethod().
                    AllowAnyHeader().
                    AllowCredentials());
                }
                // �������
                endpoints.ProcessMetrices("/metrics");
                // dotnetify �������
                endpoints.MapHub<DotNetifyHub>("/dotnetify");
            });
        }

        /// <summary>
        /// ��ȡ��������Ӧ��swagger����ֵ
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
        /// ��ȡ���еĿ�����
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
    /// Swagger ע�Ͱ�����
    /// </summary>
    public class SwaggerDocTag : IDocumentFilter
    {
        /// <summary>
        /// ��Ӹ���ע��
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            //��Ӷ�Ӧ�Ŀ���������
            swaggerDoc.Tags = new List<OpenApiTag>
            {
                new OpenApiTag { Name = "Test", Description = "��������" },
            };
        }
    }
}
