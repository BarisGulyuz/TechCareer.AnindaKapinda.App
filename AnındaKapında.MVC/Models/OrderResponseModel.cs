using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.MVC.Models
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int AdressId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int ShipmentStatus { get; set; }
    }
}
