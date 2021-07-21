using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Entities
{
    public class tblProductImage
    {
        [Key]
        public int fileId { get; set; }
        public string fileName { get; set; }
        //-----------Relationships----------------
        public tblProduct product { get; set; }
    }
}
