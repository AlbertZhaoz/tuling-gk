/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果要增加方法请在当前目录下Partial文件夹tbl_record_data_300_viewController编写
 */
using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Albert.DataQuery.IServices;
namespace VOL.Albert.DataQuery.Controllers
{
    [Route("api/tbl_record_data_300")]
    [PermissionTable(Name = "tbl_record_data_300")]
    public partial class tbl_record_data_300Controller : ApiBaseController<Itbl_record_data_300Service>
    {
        public tbl_record_data_300Controller(Itbl_record_data_300Service service)
        : base(service)
        {
        }
    }
}

