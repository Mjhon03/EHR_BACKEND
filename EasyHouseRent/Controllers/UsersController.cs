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
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        BaseData db = new BaseData(); 
        [HttpGet]
        public IEnumerable<Usuarios> Get([FromQuery] Usuarios user)
        {
            string sql = $"SELECT * FROM usuarios where email = '{user.email}' and contraseña = '{user.contraseña}'";
            DataTable dt = db.getTable(sql);
            List<Usuarios> usersList = new List<Usuarios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                             idusuario = Convert.ToInt32(dr["idusuario"]),
                             nombre = dr["nombre"].ToString(),
                             apellidos = dr["apellidos"].ToString(),
                             fechaNacimiento = dr["fechaNacimiento"].ToString(),
                             telefono = dr["telefono"].ToString(),
                             email = dr["email"].ToString(),
                             contraseña = dr["contraseña"].ToString(),
                             estado = dr["estado"].ToString(),
                             departamento = Convert.ToInt32(dr["departamento"]),
                             municipio = Convert.ToInt32(dr["municipio"])

                         }).ToList();

            return usersList;
        }

        // GET api/<UsersController>/5
        [HttpGet("{email}/{password}")]
        public void Get( )
        {
           
        }

        // POST api/<UsersController>
        [HttpPost]
        public string Post([FromBody] Usuarios user)
        {
            string sql = $"insert into usuarios (nombre,apellidos,fechaNacimiento,telefono,email,contraseña,estado,departamento,municipio) values('" + user.nombre + "','" + user.apellidos + "','" + user.fechaNacimiento + "','" + user.telefono + "','" + user.email + "','" + Encrypt.GetSHA256(user.contraseña) + "','" + user.estado + "','" + user.departamento + "','" + user.municipio + "');";
            string result = db.executeSql(sql);
            return result;
        }
        [HttpPost]
        public void PostGet( )
        {
            
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public string Put( [FromBody]Usuarios user)
        {

            string sql = "insert into usuarios (nombre,apellidos,fechaNacimiento,telefono,email,contraseña,estado) values('" + user.nombre + "','" + user.apellidos + "'," + Convert.ToDateTime(user.fechaNacimiento) + "," + user.telefono + ",'" + user.email + "','" + user.contraseña + "','" + user.estado + ");";
            string result = db.executeSql(sql);
            return result;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
