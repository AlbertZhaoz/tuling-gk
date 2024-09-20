using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace 设计模式篇002_工厂方法模式.抽象工厂设计模式实例
{
    public interface IDbLocator
    {
        public void PrintInfo();
        public SqlSugarClient GetSqlSugarClient();
    }

    public class MySQLDbLocator : IDbLocator
    {
        public void PrintInfo()
        {
            Console.WriteLine("MySQL");
        }

        public SqlSugarClient GetSqlSugarClient()
        {
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "xxx",
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            }, db => { db.Aop.OnLogExecuting = (sql, pars) => { Console.WriteLine(sql); }; });
        }
    }

    public class SQLServerDbLocator : IDbLocator
    {
        public void PrintInfo()
        {
            Console.WriteLine("SQLServer");
        }

        public SqlSugarClient GetSqlSugarClient()
        {
            // 非单例模式 
            // 单例模式：SqlSugarScope 
            return new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "xxx",
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            }, db => { db.Aop.OnLogExecuting = (sql, pars) => { Console.WriteLine(sql); }; });
        }

        public class SqliteDbLocator : IDbLocator
        {
            public void PrintInfo()
            {
                Console.WriteLine("Sqlite");
            }

            public SqlSugarClient GetSqlSugarClient()
            {
                return new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "xxx",
                    DbType = DbType.Sqlite,
                    IsAutoCloseConnection = true
                }, db => { db.Aop.OnLogExecuting = (sql, pars) => { Console.WriteLine(sql); }; });
            }
        }
    }
}