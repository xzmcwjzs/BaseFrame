using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Quartz.Net
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();//从工厂中获取一个调度器实例化
            scheduler.Start();//开始调度器
            IJobDetail job = JobBuilder.Create<TotalJob>().Build();//创建一个作业
            ITrigger trigger = TriggerBuilder.Create().WithSimpleSchedule(t => t.WithIntervalInSeconds(5).RepeatForever()).Build();//触发执行 5s一次
            scheduler.ScheduleJob(job, trigger);
            Console.ReadKey();
            #endregion

            #region HttpWebRequest
            //HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create("http://www.baidu.com");
            //using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            //{
            //    //response.StatusCode  404 500 200
            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        using (Stream stream = response.GetResponseStream())
            //        {
            //            using(StreamReader reader=new StreamReader(stream))
            //            {
            //                string html = reader.ReadToEnd();
            //                Console.WriteLine(html);
            //            }
            //        }

            //    }
            //    else
            //    {
            //        Console.WriteLine("服务器返回错误：" + response.StatusCode);
            //    }
            //}

            //Console.ReadKey(); 
            #endregion
        }
    }
}
