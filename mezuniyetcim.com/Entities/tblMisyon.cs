using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Entities
{
    public class tblMisyon
    {
        [Key]
        public int misyonId { get; set; }
        public string misyonTitle { get; set; }
        public string misyonDescription { get; set; }
    }
}
