using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Core.Log
{
    //委托版 观察者模式
    public class LogHelper
    {
        public static Queue<string> ExceptionStringQueue = new Queue<string>();
        //public static List<ILogWriter> LogWriterList = new List<ILogWriter>();
        public delegate void Handler(string info);
        private static Handler writeHandler;
        static LogHelper()
        {
            //LogWriterList.Add(new TextFileWriter());//变化点 
            // LogWriterList.Add(new Log4NetWriter());
            //加入观察者
            writeHandler += new Log4NetWriter().WriteLogInfo;

            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    lock (ExceptionStringQueue)
                    {
                        if (ExceptionStringQueue.Count > 0)
                        {
                            string str = ExceptionStringQueue.Dequeue();
                            //foreach (var logWriter in LogWriterList)
                            //{
                            //    logWriter.WriteLogInfo(str);
                            //}
                            //通过GetInvodationList方法获取多路广播委托列表，如果观察者数量大于0即执行方法
                            if (writeHandler != null)
                            {
                                if (writeHandler.GetInvocationList().Count() != 0)
                                {
                                    writeHandler(str);
                                }
                            }
                        }
                        else
                        {
                            Thread.Sleep(3000);
                        }
                    }
                }
            });
        }

        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }
    }
}
