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
            string sql = $"SELECT * FROM usuarios where email = '{user.email}' and contraseña = '{Encrypt.EncryptKey(user.contraseña)}'";
            DataTable dt = db.getTable(sql);
            List<Usuarios> usersList = new List<Usuarios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Usuarios()
                         {
                             idusuario = Convert.ToInt32(dr["idusuario"]),
                             nombre = dr["nombre"].ToString(),
                             apellidos = dr["apellidos"].ToString(),
                             edad = Convert.ToInt32(dr["edad"]),
                             telefono = dr["telefono"].ToString(),
                             email = dr["email"].ToString(),
                             contraseña = dr["contraseña"].ToString(),
                             estado = dr["estado"].ToString(),
                             departamento = Convert.ToInt32(dr["departamento"]),
                             municipio = Convert.ToInt32(dr["municipio"])

                         }).ToList();

            return usersList;



        }
        //https://localhost:44352/api/Users?email=juancito&contrase%C3%B1a=jhoncito

        // GET api/<UsersController>/5
        [HttpGet("{email}/{password}")]
        public void Get( )
        {
           
        }

        // POST api/<UsersController>
        [HttpPost]
        public string Post([FromBody] Usuarios user)
        {
            //Insertar usuario
            string sql = "INSERT INTO usuarios (nombre,apellidos,edad,telefono,email,contraseña,estado,departamento,municipio) VALUES ('" + user.nombre + "','" + user.apellidos + "','" + user.edad + "','" + user.telefono + "','" + user.email + "','" + Encrypt.EncryptKey(user.contraseña) + "','" + user.estado + "','" + user.departamento + "','" + user.municipio + "');";
            string result = db.executeSql(sql);
            return result;
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public string Put([FromBody] Usuarios user)
        {
            //Actualizar datos del Usuario
            string sql = "UPDATE usuarios SET nombre = '" + user.nombre + "', apellidos = '" + user.apellidos + "', edad = '" + user.edad + "', telefono ='" + user.telefono + "', email ='" + user.email + "', contraseña ='" + Encrypt.EncryptKey(user.contraseña) + "', estado ='" + user.estado + "', departamento ='" + user.departamento + "', municipio ='" + user.municipio + "'  WHERE idusuario = '" + user.idusuario + "'";
            string resultado = db.executeSql(sql);
            return resultado;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete]
        public string Delete([FromBody] Usuarios user)
        {
            //Eliminar Usuario
            string sql = "DELETE FROM usuarios WHERE idusuario = " + user.idusuario;
            string result = db.executeSql(sql);
            return result;
        }
    }
}
