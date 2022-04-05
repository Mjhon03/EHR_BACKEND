using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyHouseRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationEmailController : ControllerBase
    {
        // GET: api/<ConfirmationEmailController>
        BaseData db = new BaseData();
        [HttpGet]
        public IEnumerable<Usuarios> Get([FromQuery] Usuarios user)
        {
            string sql = $"SELECT email FROM usuarios where email = '{user.email}';";
            List<Usuarios> usersList = new List<Usuarios>();
            DataTable dt = db.getTable(sql);
            usersList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                             email = dr["email"].ToString(),
                         }).ToList();


            return usersList;
        }
        
        // GET api/<ConfirmationEmailController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConfirmationEmailController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ConfirmationEmailController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConfirmationEmailController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
