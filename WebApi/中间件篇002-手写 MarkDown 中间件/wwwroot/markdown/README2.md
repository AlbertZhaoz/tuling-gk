# NET_AlbertzhaozToolHelper
此项目用于收集常用的.NET套件，包含高效工具类(ToolHelper)、常用类库(CommonNuget)、项目实战(Project)、高效工具(Tools)、常用网站(Websites)、在线课程(OnlineCourse)等，以做到对 .NET 资源的整合。  
- ToolHelper：高效的第三方业务库。根据版本可与现有项目无缝集成。其中一部分收集整理的实用类库，一部分自己写的类库，分文件夹分版本，对于每个文件夹增加相关说明，并验证每一个类的有效性和正确性。
- CommonNuget：在工作中常用的 Nuget 包、第三方类库的介绍和使用文档等。
- Project：收集主流的实战项目。
- Tools：收集开发 .NET 的高效工具。
- Websites：收集 .NET 开发常用的网址。
- OnlineCourse：收集各类优秀的 .NET 视频，以 B 站、Youtube 为主。
# ToolHelper
| | | |
|-|-|-|
|Name|Description|Doc|
|[01_RsCode](https://gitee.com/kuiyu/RsCode)|**一款开箱即用的 .net 工具库，助力 .net 开发。** 基于 .NET Standard 2.1/.NET 5，可直接引用丰富的 .NET 类库。可与已有的 ASP.NET Core MVC、Razor Pages 项目无缝集成。|https://rscode.cn|
|[02_Masuit.Tools](https://github.com/ldqk/Masuit.Tools)|包含一些常用的操作类，大都是静态类，加密解密，反射操作，权重随机筛选算法，分布式短id，表达式树，linq 扩展，文件压缩，多线程下载和 FTP 客户端，硬件信息，字符串扩展方法，日期时间扩展操作，中国农历，大文件拷贝，图像裁剪，验证码，断点续传，集合扩展、Excel 导出等常用封装。**诸多功能集一身，代码量不到2MB！**|https://masuit.com/55|
|[03_dotnetcodes](https://gitee.com/kuiyu/dotnetcodes)|该项目基于MIT协议，它是一个类库，里面包含大量可直接使用的功能代码，可以帮你减少开发与调试时间,而且类与类之间没有什么依赖,每个类都可以单独拿出来使用。**此项目的动机来源于让更多的 .net 开发者更轻松高效的完成业务，很多代码都是原创，并且应用在了多个真实的项目中。**|https://gitee.com/kuiyu/dotnetcodes|
|[04_Common.Utility](https://github.com/Jimmey-Jiang/Common.Utility)|大致包含了下面这个类，并且在不断的收集和整理中:       C# 读取 AD 域里用户名或组,Chart 图形,cmd,Cookie&Session,CSV 文件转换,DataTable 转实体,DBHelper,DecimalUtility 及中文大写数字,DLL,Excel 操作类 ,FTP 操作类,H5-微信,Html 操作类,INI 文件读写类,IP 辅助类,Javascript,Json,JSON 操作,JS 操作,Lib,Mime,Net,NPOI,obj,packages,Path,PDF,Properties,QueryString 地址栏参数 ,RDLC 直接打印帮助类,ResourceManager,RMB,SqlHelper,SQL 语句拦截器,URL 的操作类,VerifyCode,XML 操作类,上传下载,二维码操作类,共用工具类,其他,分词辅助类,分页 ,加密解密,压缩解压缩,各种验证帮助类,图片,图片操作类,图片验证码,处理多媒体的公共类,处理枚举类,字符串,对象转换处理,帮助文档,序列化,异步线程,弹出消息类 ,数据展示控件绑定数据类,文件操作类,日历,日志,时间戳,时间操作类,条形码,条形码帮助类,条形码转HTML,检测是否有 Sql 危险字符,正则表达式,汉字转拼音,注册表操作类 ,科学计数，数学,类型转换,系统操作相关的公共类,缓存,网站安全,网站路径操作类,网络,视频帮助类,视频转换类,计划任务,邮件,邮件2,配置文件操作类,阿里云,随机数类,页面辅助类,验证码。|https://github.com/Jimmey-Jiang/Common.Utility|

# CommonNuget
| | | |
|-|-|-|
|Name|Description|Doc|
|[01_Winform_MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin)|Theming .NET WinForms, C# or VB.Net, to Google's Material Design Principles.|https://github.com/IgnaceMaes/MaterialSkin|
|[02_Winform_Hzhcontrols](https://github.com/kwwwvagaa/NetWinformControl)|控件集是基于 .Net Framework4.0，纯原生开发，不包含第三方插件和类库。包含了常用窗体和常用控件，以及工业工具，类Web控件，使用我们的控件可以快速的搭建一个漂亮的应用程序。|http://www.hzhcontrols.com/doc.html|
|[03_Winform_SunnyUI](https://github.com/yhuse/SunnyUI)|SunnyUI.Net, 是基于.Net Framework 4.0~4.8、.Net 6 框架的 C# WinForm 开源控件库、工具类库、扩展类库、多页面开发框架。|https://gitee.com/yhuse/SunnyUI/wikis/pages|
|[04_Winform_NanUI](https://github.com/NetDimension/NanUI/)|NanUI 界面组件是一个开放源代码的 .NET / .NET Core 窗体应用程序（WinForms）界面框架。它适用于希望使用 HTML5/CSS3 等前端技术来构建 Windows 窗体应用程序用户界面的 .NET 开发人员。         NanUI 基于谷歌可嵌入的浏览器框架 Chromium Embedded Framework (CEF)，因此用户可以使用各种前端技术 HTML5/CSS3/JavaScript 和流行前端框架 React/Vue/Angular/Blazor 设计和开发 .NET 桌面应用程序的用户界面。         同时，NanUI 独创的 JavaScript Bridge 可以方便地实现浏览器端与 .NET 之间的通信和数据交换。          使用 NanUI 界面框架将为传统的 WinForm 应用程序的用户界面设计和开发工作带来无限种可能！|https://gitee.com/linxuanchen/NanUI/blob/master/docs/zh-CN/README.md#/linxuanchen/NanUI/blob/master/docs/zh-CN/configuration.md|
|[05_Winform_ScottPlot](https://github.com/ScottPlot/ScottPlot)|只需几行代码即可创建折线图、条形图、饼图、散点图等。千万级数据处理无压力, 媲美 Python Matplotlib。支持用户和图表数据进行交互, 注入灵魂。基于 MIT 开源协议, 已经开源近5年, 不存在版权和收费问题。图表组件非常全面,可满足各种场景下的展示需求。|https://github.com/ScottPlot/ScottPlot|
|[06_SqlSugar](https://github.com/donet5/SqlSugar)|SqlSugar 是一款老牌 .NET 开源 ORM 框架，由果糖大数据科技团队维护和更新 ，开箱即用，最易上手的 ORM 框架。|https://www.donet5.com/Home/Doc|
|[07_MiniExcel](https://gitee.com/dotnetchina/MiniExcel)|MiniExcel 简单、高效避免 OOM 的 .NET 处理 Excel 查、写、填充数据工具。目前主流框架大多需要将数据全载入到内存方便操作，但这会导致内存消耗问题，MiniExcel 尝试以 Stream 角度写底层算法逻辑，能让原本1000多MB占用降低到几MB，避免内存不够情况。|https://gitee.com/dotnetchina/MiniExcel|
|[08_TouchSocket](https://github.com/RRQM/TouchSocket)|TouchSocket 这是一个轻量级的、支持插件的综合网络通信库。基础通信功能包含 Tcp、Udp、Ssl、Rpc、Http 等。其中 http 服务器支持 WebSocket、静态网页、XmlRpc、WebApi、JsonRpc等扩展插件。和自定义协议的 TouchRpc，支持 Ssl 加密、异步调用、权限管理、错误状态返回、服务回调、分布式调用等。在空载函数执行时，10万次调用仅3.8秒，在不返回状态时，仅0.9秒。|https://github.com/RRQM/TouchSocket|
|[09_csredis](https://github.com/2881099/csredis)|支持 .Net Core 和 .Net Freamwork 4.0+，相对于 ServiceStack.Redis 来说不要钱，相对于 StackExchange.Redis 来说 bug 少。|https://github.com/2881099/csredis|
|[10_AutoMapper](https://github.com/AutoMapper/AutoMapper)|AutoMapper is a simple little library built to solve a deceptively complex problem - getting rid of code that mapped one object to another. This type of code is rather dreary and boring to write, so why not invent a tool to do it for us?|https://github.com/AutoMapper/AutoMapper|
|[11_Masuit.LuceneEFCore.SearchEngine](https://github.com/ldqk/Masuit.LuceneEFCore.SearchEngine)|仅70KB的代码量！ 基于EntityFrameworkCore和Lucene.NET实现的全文检索搜索引擎，可轻松实现高性能的全文检索，支持添加自定义词库，自定义同义词和同音词，搜索分词默认支持同音词搜索。可以轻松应用于任何基于EntityFrameworkCore的实体框架数据库。    注意：该项目仅适用于单体项目的简单搜索场景，不适用于分布式应用以及复杂的搜索场景，分布式应用请考虑使用大型的搜索引擎中间件做支撑，如：ElasticSearch，或考虑数据库的正则表达式查询。|https://github.com/ldqk/Masuit.LuceneEFCore.SearchEngine|
|[12_CacheManager](https://github.com/MichaCo/CacheManager)|一个非常实用的缓存中间件，CacheManager 是用 C＃ 编写的 .NET 的开源缓存抽象层。 它支持各种缓存提供程序并实现许多高级功能。CacheManager 软件包的主要目标是使开发人员的生活更轻松，甚至可以处理非常复杂的缓存方案。借助CacheManager，可以实现多层缓存，例如 只需几行代码，即可在分布式缓存之前进行进程内缓存。CacheManager 不仅仅是统一各种缓存提供程序的编程模型的接口，这将使以后在项目中更改缓存策略变得非常容易。 它还提供了其他功能，例如缓存同步，并发更新，序列化，事件，性能计数器...开发人员只有在需要时才可以选择加入这些功能。|https://github.com/MichaCo/CacheManager|
|[13_htmldiff.net](https://github.com/Rohland/htmldiff.net)|用于比较两个HTML文件/片段的库，并使用简单的HTML突出显示差异。基于 ruby 实现的 HTMLDiff 库移植到 .NET Core 下的。|https://github.com/Rohland/htmldiff.net|
|[14_ObjectsComparer](https://github.com/ValeraT1982/ObjectsComparer)|一个对象比较器，有时候项目中会有两个对象比较里面哪些字段不一样，而不是简单地 equal 或 == 比较，这就比较麻烦，自己老老实实一个一个字段去判断显得也很繁琐，而ObjectsComparer 则是帮助你自动实现两个对象里面每个字段的逐一对比，甚至还会帮你生成差异结果告诉你某个字段值从什么变化成了什么。比较复杂对象的情况很普遍。有时对象可以包含嵌套元素，或者某些成员应从比较中排除（自动生成的标识符，创建/更新日期等），或者某些成员可以具有自定义比较规则（相同数据，但格式不同，例如电话号码）。开发这种小型框架是为了解决此类问题。简而言之，对象比较器是对象到对象的比较器，它允许逐个成员地递归比较对象，并为某些属性，字段或类型定义自定义比较规则。|https://github.com/ValeraT1982/ObjectsComparer|
|[15_Hangfire](https://github.com/HangfireIO/Hangfire)|定时任务框架|https://github.com/HangfireIO/Hangfire|

# Project
| | | |
|-|-|-|
|Name|Description|Doc|
|[01_NETworkManager](https://github.com/BornToBeRoot/NETworkManager)|管理和解决网络问题的工具。它集成了 IP 和端口扫描、WiFi 分析器、跟踪路由、DNS 查询等工具。|https://github.com/BornToBeRoot/NETworkManager|

# 如何贡献
如果你希望参与贡献，欢迎 [Pull Request](https://github.com/AlbertZhaoz/NET_AlbertzhaozToolHelper/pulls)，或给我们 [报告 Bug](https://github.com/AlbertZhaoz/NET_AlbertzhaozToolHelper/issues) 。