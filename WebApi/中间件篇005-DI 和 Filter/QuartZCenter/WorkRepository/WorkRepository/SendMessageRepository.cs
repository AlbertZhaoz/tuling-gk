using QuartZ.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WorkRepository
{
    public class SendMessageRepository : BaseRepository, ISendMessageRepository, IDIScoped
    {

        public SendMessageRepository()
        {
           
        }
        public string Test()
        {
            //DBConne.DbFirst.CreateClassFile
            DBConne.Aop.OnLogExecuted = (sql, ca) =>
            {
                Console.WriteLine("1111111111111");
                Console.WriteLine(sql);
            };

            var id = DBConne.Queryable("app_news","where id = 73783").First();
            var aaa = DBConne.Queryable("app_news",null).First();
            return id.ToString();
        }
    }
}
