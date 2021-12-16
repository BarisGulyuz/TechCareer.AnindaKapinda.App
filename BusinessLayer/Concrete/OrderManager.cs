using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void Add(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void Delete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetAll();
        }

        public Order GetById(int id)
        {
          return  _orderDal.Get(x=> x.Id == id);
        }

        public void Update(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
