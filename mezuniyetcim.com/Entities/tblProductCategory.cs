using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Entities
{
    public class tblProductCategory
    {
        [Key]
        public int productCategoryId { get; set; }
        public string productCategoryName { get; set; }
        public List<tblProduct> Products { get; set; }

    }
}
