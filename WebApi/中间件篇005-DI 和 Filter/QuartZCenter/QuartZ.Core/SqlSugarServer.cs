using System;
using SqlSugar;
using Microsoft.Extensions.DependencyInjection;

namespace QuartZ.Core
{
    public static class SqlSugarServer
    {
        /// <summary>
        /// 注入数据库连接
        /// </summary>
        public static IOCCollection AddSqlSugar(this IOCCollection iOCCollection)
            => AddSqlSugar(iOCCollection, "ConnectionStrings", DbType.MySql, LanguageType.Chinese);

        /// <summary>
        /// 注入数据库连接字符串
        /// </summary>
        /// <param name="connectionString">连接字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="languageType">语言</param>
        public static IOCCollection AddSqlSugar(this IOCCollection iOCCollection, string connectionString, DbType dbType, LanguageType languageType)
            => AddSqlSugar(iOCCollection, serviceCollection =>
            {
                serviceCollection.AddSingleton(new SqlSugarScope(new ConnectionConfig
                {
                    ConnectionString = iOCCollection.Config[connectionString],
                    DbType = dbType,
                    LanguageType = languageType,
                }));
            });

        /// <summary>
        /// 自定义SqlSugar注册
        /// </summary>
        /// <param name="iOCCollection"></param>
        /// <param name="action"></param>
        public static IOCCollection AddSqlSugar(this IOCCollection iOCCollection, Action<IServiceCollection> action)
        {
            action(iOCCollection.RDYServiceCollection);
            return iOCCollection;
        }
    }
}
