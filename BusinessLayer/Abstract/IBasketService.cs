﻿using EntityLayer.Concrete.BasketEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBasketService
    {
            Task<Basket> GetBasketAsync(string basketId);
            Task<Basket> UpdateBasketAsync(Basket basket);
            Task<bool> DeleteBasketAsync(string basktetId);
    }
}
