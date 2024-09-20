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

// ����һЩ��̬��Դ�ļ��м����·���м�����쳣�����м����һЩ֪ʶ
// �����������Է���wwwroot��Ŀ¼�µ��ļ���Ҳ���Է���ContentsĿ¼�µ��ļ���
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


// Ĭ��ҳ���м��
app.UseDefaultFiles();
app.UseDefaultFiles(defaultFilesOptions);

// ��̬��Դ�ļ��м��
app.UseStaticFiles();
app.UseStaticFiles(staticFileOptions);

// Ŀ¼�м��
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
        await context.Response.WriteAsync("CityΪ��");
    }
    
   
}

app.UseAuthorization();

app.MapRazorPages();

// �ս���м��
app.UseEndpoints(endpoints => endpoints.MapGet(template,AlbertHandlerAsync));

app.Run();
