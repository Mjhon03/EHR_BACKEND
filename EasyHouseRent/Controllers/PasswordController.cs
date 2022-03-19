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

    public class PasswordController : ControllerBase
    {
        BaseData db = new BaseData();
        // GET: api/<PasswordController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PasswordController>/5
        [HttpGet("{id}")]
        [Route("api/Password/{idusuario}")]
        public IEnumerable<Usuarios> GetPassword(int id, [FromBody] Usuarios user)
        {
            string sql = $"SELECT idusuario,contraseña FROM usuarios WHERE idusuario = '{id}' AND contraseña = '{user.contraseña}'";
            DataTable dt = db.getTable(sql);
            List<Usuarios> usersList = new List<Usuarios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                             idusuario = Convert.ToInt32(dr["idusuario"]),
                             contraseña = dr["contraseña"].ToString(),

                         }).ToList();

            return usersList;
        }

        // POST api/<PasswordController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PasswordController>/5
        [HttpPut]
        public string Put([FromQuery] Usuarios user)
        {
            string sql = "UPDATE usuarios SET contraseña = '" + user.contraseña + "'  WHERE idusuario = '" + user.idusuario + "'";
            string resultado = db.executeSql(sql);
            return resultado;
        }

        // DELETE api/<PasswordController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
