using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationDemo
{
    public class TotalJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
             
            KeyWordsTotalService bll = new KeyWordsTotalService(); 
            bll.DeleteAllKeyWordsRank(); 
            bll.InsertKeyWordsRank(); 
        }
    }
}
