/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹Albert_DataSecondReworkController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.DataQuery.IServices;
namespace VOL.Albert.DataQuery.Controllers
{
    [Route("api/Albert_DataSecondRework")]
    [PermissionTable(Name = "Albert_DataSecondRework")]
    public partial class Albert_DataSecondReworkController : ApiBaseController<IAlbert_DataSecondReworkService>
    {
        public Albert_DataSecondReworkController(IAlbert_DataSecondReworkService service)
        : base(service)
        {
        }
    }
}

