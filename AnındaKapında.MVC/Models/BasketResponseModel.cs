using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.MVC.Models
{
    public class BasketResponseModel
    {

        public string Id { get; set; }
        public List<BasketItemsResponseModel> Items { get; set; } = new List<BasketItemsResponseModel>();
    }
}
