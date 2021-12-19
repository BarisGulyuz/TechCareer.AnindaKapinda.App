using BusinessLayer.Abstract;
using BusinessLayer.Enums;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnındaKapında.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _workerService.GetAll();
            return Ok(values);
        }


        [HttpGet]
        [Route("SupplyOfficers")]
        public IActionResult SupplyOfficers()
        {
            var values = _workerService.GetWorkersByTyoe((int)WorkerTypeEnum.SupplyOfficer);
            return Ok(values);
        }

        [HttpGet]
        [Route("CargoOfficers")]
        public IActionResult GetCargoOfficers()
        {
            var values = _workerService.GetWorkersByTyoe((int)WorkerTypeEnum.CargoOfficer);
            return Ok(values);
        }


        [HttpPost]
        public IActionResult AddWorker(Worker worker)
        {
             worker.RoleId = (int)(RoleEnum.Worker);
            _workerService.Add(worker);
            return Created("", worker);
        }
    }
}
