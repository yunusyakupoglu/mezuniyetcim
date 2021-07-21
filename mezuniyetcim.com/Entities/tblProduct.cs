using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Entities
{
    public class tblProduct
    {
        public tblProduct()
        {

        }
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }

        [NotMapped]
        public int productCategoryID { get; set; }
        [NotMapped] //Veritabanına yansımamasını sağlar.
        public IFormFile[] Files { get; set; }
        //public string FileName { get; set; }
        //-----------Relationships----------------
        public List<tblProductImage> productImages { get; set; } = new();
        public tblProductCategory  productCategory { get; set; }
    }
}
