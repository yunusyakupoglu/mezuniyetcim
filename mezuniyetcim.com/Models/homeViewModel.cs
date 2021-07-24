using mezuniyetcim.com.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Models
{
    public class homeViewModel
    {
        public List<tblProduct> products { get; set; }
        public List<tblProductCategory> productCategories { get; set; }
        public List<tblProductImage> productImages { get; set; }
        public List<tblVizyon> vizyons { get; set; }
        public List<tblMisyon> misyons { get; set; }
        public List<tblAddress> addresses { get; set; }
        public List<tblPhone> phones { get; set; }
        public List<tblMail> mails { get; set; }
    }
}
