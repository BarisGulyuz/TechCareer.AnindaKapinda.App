using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Worker: User
    {
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkerTypeId { get; set; }
        public WorkerType WorkerType { get; set; }
    }
}
