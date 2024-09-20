using System.Text;
using MarkdownSharp;
using Microsoft.Extensions.Caching.Memory;
using Ude;

namespace NET_FiveMinutes_007_MarkdownMiddleware.Middlewares
{
    public class MarkDownViewerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;
        private readonly IMemoryCache _memoryCache;

        public MarkDownViewerMiddleware(RequestDelegate next,IWebHostEnvironment environment,IMemoryCache memoryCache)
        {
            this._next = next;
            this._environment = environment;
            this._memoryCache = memoryCache;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //拼接请求
            string path = "markdown"+context.Request.Path.Value??"";

            // 如果用户请求的不是markdown文件，则转到下一个中间件
            if(!path.EndsWith(".md"))
            {
                await _next(context);
                return;
            }

            // 转换markdown为html
            var file = _environment.WebRootFileProvider.GetFileInfo(path);
            if(!file.Exists)
            {
                await _next(context);
                return;
            }

            context.Response.ContentType = $"text/html;charset=UTF-8";
            context.Response.StatusCode = 200;
            // 将中间件名称+文件名+文件修改时间作为缓存key
            // 一旦文件修改，则会立即获取最新文件
            string cacheKey = nameof(MarkDownViewerMiddleware)+path+file.LastModified;
            var html = await _memoryCache.GetOrCreateAsync(cacheKey,async ce=>
            {
                ce.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                using var stream = file.CreateReadStream();
                string text = await ReadText(stream);
                // MarkdownSharp包：将mkdown文件流转换为Html格式
                // 只能转换普通的格式，带表格的无法转换
                Markdown mkMarkdown = new Markdown();
                return mkMarkdown.Transform(text);
            });

            await context.Response.WriteAsync(html);
        }

        /// <summary>
        /// 探测流编码
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private string DetectCharset(Stream stream)
        {
            CharsetDetector detector = new CharsetDetector();
            detector.Feed(stream);
            detector.DataEnd();
            string charset = detector.Charset??"UTF-8";
            stream.Position = 0;
            return charset;
        }

        /// <summary>
        /// Ude.NetStandard 从md文件中探测流，并读取文本内容
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>

        private async Task<string> ReadText(Stream stream)
        {
            string charset = DetectCharset(stream);
            using var reader = new StreamReader(stream,Encoding.GetEncoding(charset));
            return await reader.ReadToEndAsync();
        }

    }
}
