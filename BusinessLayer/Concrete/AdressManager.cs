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
    
    public class AdressManager: IAdressService
    {
        IAdressDal _addressDal;

        public AdressManager(IAdressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void Add(Adress entity)
        {
            _addressDal.Add(entity);
        }

        public void Delete(Adress entity)
        {
            _addressDal.Delete(entity);
        }

        public List<Adress> GetAll()
        {
            return _addressDal.GetAll();
        }

        public Adress GetById(int id)
        {
            return _addressDal.Get(x => x.Id == id);
        }

        public void Update(Adress entity)
        {
            _addressDal.Update(entity);
        }
    }
}
