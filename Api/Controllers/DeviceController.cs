using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Concrete;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceController : ControllerBase
    {
        GenericRepository<Device> genericRepository = new GenericRepository<Device>();

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            List<Device> list = genericRepository.GetAll();

            return Ok(list);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById(string id)
        {
            int myId = int.Parse(id);

            Device obj = genericRepository.GetById(o => o.Id == myId);

            if(obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpGet]
        [Route("getbystation/{id}")]
        public IActionResult GetByStation(int id)
        {
            List<Device> devices = genericRepository.GetAll().Where(o => o.StationId == id).ToList();
            return Ok(devices);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] Device employee)
        {
            if(employee == null)
                return BadRequest();

            genericRepository.Add(employee);

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Device employee)
        {
            if(employee == null)
                return BadRequest();

            genericRepository.Update(employee);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(string id)
        {
            int deletedId = int.Parse(id);

            Device deletedObj = genericRepository.GetById(o => o.Id == deletedId);

            if(deletedObj == null)
                return BadRequest();

            genericRepository.Delete(o => o.Id == deletedId);

            return Ok();
        }
    }
}