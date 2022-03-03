using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        BaseData db = new BaseData();

        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<Departamento> Get([FromQuery] Departamento dep)
        {
            string sql = "SELECT * FROM departamento ";
            DataTable dt = db.getTable(sql);
            List<Departamento> usersList = new List<Departamento>();
            usersList = (from DataRow dr in dt.Rows
                         select new Departamento()
                         {
                             iddepartamento = Convert.ToInt32(dr["iddepartamento"]),
                             nombre = dr["nombre"].ToString(),
                         }).ToList();

            return usersList;
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public void Get(int id)
        {

        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
