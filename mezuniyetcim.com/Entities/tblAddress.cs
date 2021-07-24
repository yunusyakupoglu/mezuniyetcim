using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mezuniyetcim.com.Entities
{
    public class tblAddress
    {
        [Key]
        public int adresId { get; set; }
        public string Sehir { get; set; }
        public string İlce { get; set; }
        public string Mahalle { get; set; }
        public string Cadde { get; set; }
        public string Sokak { get; set; }
        public string adresTanımı { get; set; }
    }
}
