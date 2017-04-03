using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Model.Entities
{
   public  class SysModule
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name ="模块名称")]
        public string Name { get; set; } 
        [MaxLength(200)]
        [Display(Name = "英文名称")]
        public string EnglishName { get; set; } 
        [MaxLength(50)]
        [Display(Name = "上级ID这是一个tree")]
        public string ParentId { get; set; } 
        [MaxLength(200)]
        [Display(Name = "链接")]
        public string Url { get; set; }
        [MaxLength(200)]
        [Display(Name = "图标")]
        public string Iconic { get; set; } 
        [Display(Name = "排序")]
        public int Sort { get; set; }
        [MaxLength(4000)]
        [Display(Name = "说明")]
        public string Remark { get; set; }
        [MaxLength(50)]
        [Display(Name = "状态")]
        public string State { get; set; }
        [MaxLength(200)]
        [Display(Name = "创建人")]
        public string CreatePerson { get; set; } 
        [Display(Name = "创建时间")]
        public DateTime? CreateTime { get; set; }
        [Required] 
        [Display(Name = "是否是最后一项")]
        public bool IsLast { get; set; }
        [MaxLength(50)]
        [Display(Name = "版本")]
        public string Version { get; set; }
    }
}
