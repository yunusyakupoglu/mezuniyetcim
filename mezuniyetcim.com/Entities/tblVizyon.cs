using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Entities
{
    public class tblVizyon
    {
        [Key]
        public int vizyonId { get; set; }
        public string vizyonTitle { get; set; }
        public string vizyonDescription { get; set; }
    }
}
