using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using NET_FiveMinutes_007_MarkdownMiddleware.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MarkDownViewerMiddleware2>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

//app.UseMiddleware<MarkDownViewerMiddleware>();
app.UseMiddleware<MarkDownViewerMiddleware2>();

// 补充一些静态资源文件中间件、路由中间件、异常处理中间件的一些知识
// 这样不仅可以访问wwwroot根目录下的文件，也可以访问Contents目录下的文件了
var contentTypeProvider = new FileExtensionContentTypeProvider();
contentTypeProvider.Mappings.Add(".abc","text/plain");
var staticFileOptions = new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory+"contents"),
    RequestPath = "/contents",
    ContentTypeProvider = contentTypeProvider
};

var directoryBrowserOptions = new DirectoryBrowserOptions()
{
    FileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory+"contents"),
    RequestPath = "/contents"
};

var defaultFilesOptions = new DefaultFilesOptions()
{
    FileProvider = new PhysicalFileProvider(AppDomain.CurrentDomain.BaseDirectory+"contents"),
    RequestPath = "/contents"
};


// 默认页面中间件
app.UseDefaultFiles();
app.UseDefaultFiles(defaultFilesOptions);

// 静态资源文件中间件
app.UseStaticFiles();
app.UseStaticFiles(staticFileOptions);

// 目录中间件
app.UseDirectoryBrowser();
app.UseDirectoryBrowser(directoryBrowserOptions);

app.UseRouting();

const string template = @"weather/{city}/{days:int:range(1,4)}";
async Task AlbertHandlerAsync(HttpContext context)
{
    var city = (string)context.GetRouteData().Values["city"];
    if (city != null)
    {
        var days = DateTime.Now.AddDays(int.Parse(city.ToString())).ToString();
        await context.Response.WriteAsync($"{city}\r\n{days}");
    }
    else
    {
        await context.Response.WriteAsync("City为空");
    }
    
   
}

app.UseAuthorization();

app.MapRazorPages();

// 终结点中间件
app.UseEndpoints(endpoints => endpoints.MapGet(template,AlbertHandlerAsync));

app.Run();
