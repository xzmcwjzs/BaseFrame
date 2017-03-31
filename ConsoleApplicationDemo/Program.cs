using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IScheduler scheduler=StdSchedulerFactory.GetDefaultScheduler();//从工厂中获取一个调度器实例化
            scheduler.Start();//开始调度器
            IJobDetail job = JobBuilder.Create<TotalJob>().Build();//创建一个作业
            ITrigger trigger = TriggerBuilder.Create().WithSimpleSchedule(t=>t.WithIntervalInSeconds(5).RepeatForever()).Build();//触发执行 5s一次
            scheduler.ScheduleJob(job, trigger); 
            Console.ReadKey();
        }
    }
}
