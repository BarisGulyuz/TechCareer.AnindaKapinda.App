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
    public class ProductManger : IProductService
    {
        IProductDal _productdal;

        public ProductManger(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public void Add(Product entity)
        {
            //Validation
            _productdal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productdal.Delete(entity);
        }

        public List<Product> GetAll()
        {
           return _productdal.GetAll();
        }

        public Product GetById(int id)
        {
            return _productdal.Get(x => x.Id == id);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productdal.GetAll(x => x.CategoryId == categoryId);
        }

        public void Update(Product entity)
        {
             _productdal.Update(entity);
        }
    }
}
