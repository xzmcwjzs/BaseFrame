using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ntu.xzmcwjzs.IDAL.IRepositories; 
using ntu.xzmcwjzs.Common;

namespace ntu.xzmcwjzs.BLL.Services
{
    public partial class TestService:BaseService<Test>,ITestService
    {
        public List<Test> GetList(ref GridPager pager)        {
            IQueryable<Test> queryData = null;
            queryData = repository.LoadEntities(t => true);
            if (pager.order == "desc")
            {
                switch (pager.sort)
                {
                    case "createtime":
                        queryData = queryData.OrderByDescending(c => c.createtime);
                        break;
                    case "name":
                        queryData = queryData.OrderByDescending(c => c.name);
                        break;
                    default:
                        queryData = queryData.OrderByDescending(c => c.id);
                        break;
                }
            }
            else
            {
                switch (pager.sort)
                {
                    case "createtime":
                        queryData = queryData.OrderByDescending(c => c.createtime);
                        break;
                    case "name":
                        queryData = queryData.OrderByDescending(c => c.name);
                        break;
                    default:
                        queryData = queryData.OrderByDescending(c => c.id);
                        break;
                }
            }
            return CreateModelList(ref pager, ref queryData);
        }
        private List<Test> CreateModelList(ref GridPager pager, ref IQueryable<Test> queryData)
        {
            pager.totalRows = queryData.Count(); 
            if (pager.totalRows > 0)
            {
                if (pager.totalPages <= 1)
                {
                    queryData = queryData.Take(pager.rows);
                }
                else
                {
                    queryData = queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
                }
            }
            List<Test> modelList = (from t in queryData.ToList()
                                              select new Test
                                              {
                                                   id=t.id,
                                                   name=t.name,
                                                   password=t.password,
                                                   id_card_num=t.id_card_num,
                                                   birthdate=t.birthdate,
                                                   photo=t.photo,
                                                   createtime=t.createtime
                                              }).ToList();

            return modelList;
        }

    }
}
