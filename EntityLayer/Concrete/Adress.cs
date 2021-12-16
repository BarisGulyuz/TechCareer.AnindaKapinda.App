using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Adress : BaseEntity
    {
        public string AdressTitle { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string AdressDescription { get; set; }
        public int PostCode { get; set; }
        public int? UserId { get; set; } //Fix it
        public User User { get; set; }
    }
}
