using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using VOL.Core.Utilities;
using VOL.Entity.AttributeManager;

namespace VOL.WebApi.Controllers.System.Partial
{
    [AllowAnonymous]
    [Route("api/Sys_Json")]
    public class Sys_JsonController : Controller
    {
        private WebResponseContent webResponse = null;

        /// <summary>
        /// 获取 Json 文件内容
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetConfigJsonContent")]
        public async Task<WebResponseContent> GetConfigJsonContent(string jsonFilePath)
        {
            webResponse = new WebResponseContent();

            // 判断文件是否存在
            if (global::System.IO.File.Exists(jsonFilePath))
            {
                try
                {
                    var content = global::System.IO.File.ReadAllText(jsonFilePath)
                        .Replace("\r\n", "");
                    webResponse.Data = content;

                    return webResponse.OK();
                }
                catch (Exception ex)
                {
                    webResponse.Data = ex.Message;
                    return webResponse.Error();
                }
            }
            else
            {
                webResponse.Data = "本地文件不存在";
                return webResponse.Error();
            }
        }
    }
}
