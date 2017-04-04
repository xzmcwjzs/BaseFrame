using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Model.ViewModel
{
  public  class TreeViewModel
    {
        public string id { get; set; }  //节点的id值
        public string text { get; set; }  //节点显示的名称

        public string state { get; set; } //节点的状态 
        public bool Checked { get; set; } //注意：转成JsonTreeString时，将"Checked"替换成"checked",否则选中效果出不来的

        public string url { get; set; }
        public string icon { get; set; } 
        public List<TreeViewModel> children { get; set; }  //集合属性，可以保存子节点
    }
}
