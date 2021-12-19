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
    
   public class WorkerManager: IWorkerService
    {
        IWorkerDal _workerDal;

        public WorkerManager(IWorkerDal workerDal)
        {
            _workerDal = workerDal;
        }

        public void Add(Worker entity)
        {
            _workerDal.Add(entity);
        }

        public void Delete(Worker entity)
        {
            _workerDal.Delete(entity);
        }

        public List<Worker> GetAll()
        {
            return _workerDal.GetAll();
        }

        public Worker GetById(int id)
        {
          return  _workerDal.Get(x=> x.Id == id);
        }

        public List<Worker> GetWorkersByTyoe(int typeId)
        {
            return _workerDal.GetAll(x => x.WorkerTypeId == typeId);
        }

        public void Update(Worker entity)
        {
            _workerDal.Update(entity);
        }
    }
}
