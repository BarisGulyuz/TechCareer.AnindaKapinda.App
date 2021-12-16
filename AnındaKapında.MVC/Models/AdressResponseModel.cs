using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.MVC.Models
{
    public class AdressResponseModel
    {
        public int Id { get; set; }
        public string AdressTitle { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string AdressDescription { get; set; }
        public int PostCode { get; set; }
    }
}
