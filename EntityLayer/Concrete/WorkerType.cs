using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
     public  class WorkerType: BaseEntity
    {
        public string Description { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }
}
