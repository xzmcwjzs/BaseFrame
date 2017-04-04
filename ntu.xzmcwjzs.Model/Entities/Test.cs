using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Model.Entities
{
   public class Test
    {
        [Key]
        [Required(ErrorMessage = "编号必须")]
        public string id { get; set; }
        [Required(ErrorMessage ="用户名必须")]
        [MaxLength(50)]
        public string name { get; set; }
        [Required(ErrorMessage ="密码必须")]
        [MaxLength(50)]
        public string password { get; set; }
        [Required(ErrorMessage ="身份证号必须")]
        [MaxLength(50)]
        public string id_card_num { get; set; } 
        public DateTime? birthdate { get; set; }
        [MaxLength(50)]
        public string photo { get; set; }
        [Required(ErrorMessage = "创建日期必须")]
        public DateTime createtime { get; set; }
    }
}
