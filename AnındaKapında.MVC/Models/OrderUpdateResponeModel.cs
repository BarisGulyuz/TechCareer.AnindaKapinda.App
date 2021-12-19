using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.MVC.Models
{
    public class OrderUpdateResponeModel
    {
        public int Id { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int ShipmentStatus { get; set; }
    }
}
