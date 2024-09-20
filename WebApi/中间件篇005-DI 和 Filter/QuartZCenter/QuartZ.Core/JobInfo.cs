using Quartz;
using System;

namespace QuartZ.Core
{
    public class JobInfo
    {
        public JobInfo(Type JobType)
        {
            this.JobType = JobType;
        }
        private const string DefaultJobGroupName = "DefaultJobGroup";
        private const string DefaultTriggerGroupName = "DefaultTriggerGroup";
        private string GUID { get => Guid.NewGuid().ToString(); }

        #region JobInfo
        /// <summary>
        /// Job任务类,必须为实现了IJob的接口类
        /// </summary>
        public Type JobType { get; set; }
        private string _jobName;
        /// <summary>
        /// Job名称
        /// </summary>
        public string JobName { get => _jobName ?? GUID; set { _jobName = value; } }
        private string _jobGroup;
        /// <summary>
        /// Job组
        /// </summary>
        public string JobGroup { get => _jobGroup ?? DefaultJobGroupName; set { _jobGroup = value; } }
        /// <summary>
        /// 当前Job任务描述
        /// </summary>
        public string JobDescription { get; set; } = String.Empty;
        #endregion

        #region Trigger
        private string _triggerName { get; set; }

        /// <summary>
        /// 计划名称
        /// </summary>
        public string TriggerName { get => _triggerName ?? GUID; set { _triggerName = value; } }
        private string _triggerGroup { get; set; }
        /// <summary>
        /// 计划组
        /// </summary>
        public string TriggerGroup { get => _triggerGroup ?? DefaultTriggerGroupName; set { _triggerGroup = value; } }
        /// <summary>
        /// 是否启动后立即执行一次
        /// </summary>
        public bool StartNow { get; set; }
        /// <summary>
        /// 重复执行次数,-1为永远执行。默认为-1
        /// </summary>
        public int RepeatCount { get; set; } = -1;
        /// <summary>
        /// 执行间隔毫秒,默认1秒
        /// </summary>
        public double Milliseconds { get; set; } = 1000;

        /// <summary>
        /// ***高优先度***
        /// 声明此Action将不会使用默认配置Milliseconds与RepeatForever
        /// 调用示例：s => s.WithInterval(TimeSpan.FromMilliseconds(0.1)).RepeatForever()
        /// </summary>
        public Action<SimpleScheduleBuilder> Action { get; set; } = null;
        #endregion

    }
}
