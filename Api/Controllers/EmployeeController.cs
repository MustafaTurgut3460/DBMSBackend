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
    public class EmployeeController : ControllerBase
    {
        GenericRepository<Employee> genericRepository = new GenericRepository<Employee>();

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            List<Employee> list = genericRepository.GetAll();

            return Ok(list);
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById(string id)
        {
            int myId = int.Parse(id);

            Employee obj = genericRepository.GetById(o => o.Id == myId);

            if(obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpGet]
        [Route("getbypassword/{password}")]
        public IActionResult GetByPassword(string password)
        {
            List<Employee> employees = genericRepository.GetAll();
            Employee employee = employees.FirstOrDefault(o => o.Password == password);

            if(employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpGet]
        [Route("getonline")]
        public IActionResult GetOnlineUser()
        {
            Employee employee = genericRepository.GetAll().FirstOrDefault(o => o.Status == "online");

            if(employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add([FromBody] Employee employee)
        {
            if(employee == null)
                return BadRequest();

            genericRepository.Add(employee);

            return Ok(employee);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update([FromBody] Employee employee)
        {
            if(employee == null)
                return BadRequest();

            genericRepository.Update(employee);

            return Ok(employee);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(string id)
        {
            int deletedId = int.Parse(id);

            Employee deletedObj = genericRepository.GetById(o => o.Id == deletedId);

            if(deletedObj == null)
                return BadRequest();

            genericRepository.Delete(o => o.Id == deletedId);

            return Ok(deletedObj);
        }
    }
}