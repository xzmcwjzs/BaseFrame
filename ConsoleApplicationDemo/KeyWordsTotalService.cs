using ntu.xzmcwjzs.Model.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ntu.xzmcwjzs.ADODAL;
using System.Data;

namespace ConsoleApplicationDemo
{
    public class KeyWordsTotalService
    { 
        /// <summary>
        /// 将统计的明细表的数据插入。
        /// </summary>
        /// <returns></returns>
        public bool InsertKeyWordsRank()
        {
            string sql = "insert into SearchTotal(Id,KeyWords,SearchCounts) select newid(),KeyWords,count(*)  from SearchDetail where DateDiff(day,SearchDetail.SearchDateTime,getdate())<=7 group by SearchDetail.KeyWords";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql)>0; 
        }
        /// <summary>
        /// 删除汇总中的数据。
        /// </summary>
        /// <returns></returns>
        public bool DeleteAllKeyWordsRank()
        {
            string sql = "truncate table SearchTotal";
            return SqlHelper.ExecuteNonQuery(CommandType.Text, sql) > 0;
        }
    }
}

