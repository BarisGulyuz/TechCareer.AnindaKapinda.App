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
    public class OrderLineManager : IOrderLineService
    {
        IOrderLinesDal _orderLineDal;

        public OrderLineManager(IOrderLinesDal orderLineDal)
        {
            _orderLineDal = orderLineDal;
        }

        public void Add(OrderLine entity)
        {
            _orderLineDal.Add(entity);
        }

        public void Delete(OrderLine entity)
        {
            _orderLineDal.Delete(entity);
        }

        public List<OrderLine> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderLine GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderLine> GetOrderLinesbyOrder(int orderId)
        {
            return _orderLineDal.GetAll(x => x.OrderId == orderId);
        }

        public void Update(OrderLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
