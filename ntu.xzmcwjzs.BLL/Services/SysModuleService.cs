using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using ntu.xzmcwjzs.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.BLL.Services
{
    public partial class SysModuleService : BaseService<SysModule>, ISysModuleService
    {
        
        public   List<TreeViewModel> ToTreeNodesByPid(string pid)
        {
            List<TreeViewModel> listNodes = new List<TreeViewModel>();
            var moduleList = repository.LoadEntities(t => true).Where(t=>t.Id != "0").Distinct().OrderBy(t => t.Sort).ToList();
            //生成 树节点时，根据 pid=0的根节点 来生成
            LoadTreeNode(moduleList, listNodes, pid);
              
            return listNodes;
        }

        private static List<TreeViewModel> LoadTreeNode(List<SysModule> moduleList,List<TreeViewModel> listNodes,string pid)
        {
            if (moduleList.Count > 0)
            {
                foreach (var item in moduleList)
                {
                    if (item.ParentId == pid)
                    {
                        TreeViewModel node = new TreeViewModel
                        {
                            id = item.ParentId,
                            text = item.Name,
                            state = "open",
                            Checked = false,
                            url = item.Url,
                            icon = item.Iconic,
                            children = new List<TreeViewModel>()
                        };
                        listNodes.Add(node);
                        //递归 为这个新创建的 树节点找 子节点
                        if (!item.IsLast)
                        {
                            LoadTreeNode(moduleList, node.children, item.Id);
                        }
                        else { continue; }
                        
                    }
                }
                 
            }
            return listNodes;
        }

    }
}
