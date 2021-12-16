using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Order : BaseEntity
    {
        public string CustomerName { get; set; }
        public int AdressId { get; set; }
        public Adress Adress { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int ShipmentStatus { get; set; }
        public List<OrderLine> OrderLines { get; set; }

    }
}