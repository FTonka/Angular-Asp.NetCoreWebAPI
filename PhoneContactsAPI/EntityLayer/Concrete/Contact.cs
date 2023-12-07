using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(50)]
        public string ContactName { get; set; }
        [StringLength(13)]
        public string ContactPhone { get; set; }
        [StringLength(50)]
        public string ContactJob { get; set; }
        [StringLength(50)]
        public string ContactEmail { get; set; }
        [StringLength(150)]
        public string ContactAddress { get; set; }
        [StringLength(150)]
        public string ContactWebPage { get; set; }
        [StringLength(100)]
        public string ContactImage { get; set; }

    }
}
