using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Model.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        [StringLength(100)]
        [Display(Name = "文章标题")]
        public string Title { get; set; }
        [StringLength(int.MaxValue)]
        [Display(Name = "文章内容")]
        public string Content { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}
