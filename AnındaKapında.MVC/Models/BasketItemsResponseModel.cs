using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.MVC.Models
{
    public class BasketItemsResponseModel
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public int Category { get; set; }
    }
}
