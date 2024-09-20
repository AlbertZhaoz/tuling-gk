using System;
using Quartz;
using Quartz.Impl;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace QuartZ.Core
{
    public static class QuartZService
    {
        #region 配置文件QuartZ，适合秒级以上的

        /// <summary>
        /// 运行配置文件QuartZ,最低运行间隔1秒，更短间隔，请使用AddFastQuartZ
        /// </summary>
        public static IOCCollection RunConfigureQuartZ(this IOCCollection iOCCollection)
        {
            StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult().Start();
            return iOCCollection;
        }
        #endregion

        #region 手动配置QuartZ
        /// <summary>
        /// 手动配置QuartZ，提供已完成初始化Start的IScheduler
        /// </summary>
        /// <param name="iOCCollection"></param>
        /// <param name="jobScheduler"></param>
        /// <returns></returns>
        public static IOCCollection RunFullFastQuartZ(this IOCCollection iOCCollection, Action<IScheduler> jobScheduler)
        {
            StdSchedulerFactory factory = iOCCollection.GetServices<StdSchedulerFactory>();
            IScheduler scheduler = factory.GetScheduler().GetAwaiter().GetResult();
            scheduler.Start();
            jobScheduler(scheduler);
            return iOCCollection;
        }

        /// <summary>
        /// 手动配置QuartZ
        /// </summary>
        /// <param name="iOCCollection">IOC容器</param>
        /// <param name="jobDic">Job信息和任务计划</param>
        /// <returns></returns>
        public static IOCCollection RunFullFastQuartZ(this IOCCollection iOCCollection, Dictionary<IJobDetail, ITrigger> jobDic)
            => RunFullFastQuartZ(iOCCollection, scheduler =>
            {
                foreach (var job in jobDic)
                {
                    scheduler.ScheduleJob(job.Key, job.Value);
                }
            });

        /// <summary>
        /// 手动配置简单的QuartZ，支持毫秒级操作
        /// </summary>
        /// <param name="iOCCollection">IOC容器</param>
        /// <param name="jobDetailList">一组Job</param>
        /// <returns></returns>
        public static IOCCollection RunFullFastQuartZ(this IOCCollection iOCCollection, Func<List<JobInfo>> jobDetailList)
            => RunFullFastQuartZ(iOCCollection, scheduler =>
              {
                  List<JobInfo> _jobList = new List<JobInfo>();
                  _jobList = jobDetailList();
                  foreach (var item in _jobList)
                  {
                      IJobDetail jobDetail = JobBuilder.Create(item.JobType)
                                        .WithIdentity(item.JobName, item.JobGroup)
                                        .WithDescription(item.JobDescription)
                                        .Build();

                      //时间策略
                      TriggerBuilder trigger = TriggerBuilder.Create()
                          .WithIdentity(item.TriggerName, item.TriggerGroup);
                      if (item.StartNow)
                      {
                          trigger.StartNow();
                      }
                      if (item.Action != null)
                      {
                          trigger.WithSimpleSchedule(item.Action);
                      }
                      else
                      {
                          if (item.RepeatCount == -1)
                          {
                              trigger.WithSimpleSchedule(s => s.WithInterval(TimeSpan.FromMilliseconds(item.Milliseconds)).RepeatForever());
                          }
                          else
                          {
                              trigger.WithSimpleSchedule(s => s.WithInterval(TimeSpan.FromMilliseconds(item.Milliseconds)).WithRepeatCount(item.RepeatCount));
                          }
                      }
                      //把时间策略和作业放入计划中
                      scheduler.ScheduleJob(jobDetail, trigger.Build());
                  }
              });

        /// <summary>
        /// 手动配置简单的QuartZ，支持毫秒级操作
        /// </summary>
        /// <param name="iOCCollection">IOC容器</param>
        /// <param name="jobDetails">一组Job</param>
        /// <returns></returns>
        public static IOCCollection RunFullFastQuartZ(this IOCCollection iOCCollection, params JobInfo[] jobDetails)
            => RunFullFastQuartZ(iOCCollection, () => jobDetails.ToList());

        /// <summary>
        /// 手动配置简单的QuartZ，支持毫秒级操作
        /// </summary>
        /// <param name="iOCCollection">IOC容器</param>
        /// <param name="jobDetail">一组Job</param>
        /// <returns></returns>
        public static IOCCollection RunFullFastQuartZ(this IOCCollection iOCCollection, Action<JobInfo> jobDetail)
            => RunFullFastQuartZ(iOCCollection, () =>
            {
                Type stringType = typeof(string);
                JobInfo jobInfo = new JobInfo(stringType);
                jobDetail(jobInfo);
                if (jobInfo.JobType == stringType)
                {
                    throw new ArgumentException("任务类尚未指定，请先指定任务类再生成计划，任务类名称：JobType");
                }
                return new List<JobInfo> { jobInfo };
            });
        
        #endregion

        /// <summary>
        /// 停止当前线程
        /// </summary>
        /// <param name="iOCCollection"></param>
        /// <returns></returns>
        public static IOCCollection BlockCurrentThread(this IOCCollection iOCCollection)
        {
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
