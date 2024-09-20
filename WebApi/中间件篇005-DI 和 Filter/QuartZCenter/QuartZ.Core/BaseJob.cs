using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuartZ.Core
{
    public abstract class BaseJob : IJob
    {
        #region Field Area

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetInstance<T>() => IOCCollection.GetService<T>();
        /// <summary>
        /// 异常回调事件记录
        /// </summary>
        public event Action<string> ExceptionLogger = null;

        #endregion

        /// <summary>
        /// Job 接口实现
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                BeforeExcute(context);
                Excute(context);
                AfterExcute(context);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw ExceptionCatch(context, e);
            }

        }

        /// <summary>
        /// 任务流实现类
        /// </summary>
        /// <param name="context">Job的上下文</param>
        public abstract void Excute(IJobExecutionContext context);

        #region AOP

        /// <summary>
        /// 简单用作AOP的扩展
        /// 执行任务之前
        /// 可覆写逻辑
        /// </summary>
        /// <param name="context"></param>
        public virtual void BeforeExcute(IJobExecutionContext context)
        {
        }

        /// <summary>
        /// 简单用作AOP的扩展
        /// 执行任务之后
        /// 可覆写逻辑
        /// </summary>
        /// <param name="context"></param>
        public virtual void AfterExcute(IJobExecutionContext context)
        {
        }

        /// <summary>
        /// 全局异常捕获处理机制
        /// ===================
        /// 1.异常任务报错信息会显示在控制台窗口中
        /// 2.异常任务报错信息会显示在调试输出窗口中
        /// 3.异常任务报错信息会走回调ExceptionLogger（没有配置则忽略）
        /// ===================
        /// 异常会重新抛出，非原堆栈。调试请看日志信息
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public virtual Exception ExceptionCatch(IJobExecutionContext context, Exception exception)
        {
            string exMsg = exception.Message + "\r\n"
                            + exception.StackTrace + "\r\n"
                            + exception.Source + "\r\n"
                            ;
            Console.WriteLine(exMsg);
            System.Diagnostics.Debug.WriteLine(exMsg);
            if (ExceptionLogger != null)
            {
                ExceptionLogger(exMsg);
            }
            return exception;
        }

        #endregion

    }
}
