using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.Model.Entities
{
    public class SearchTotal
    {
        public Guid Id { get; set; }
        [StringLength(50)]
        public string KeyWords { get; set; }
        public int SearchCounts { get; set; }
    }
}
