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
    public class AdvertisementController : ControllerBase
    {

        BaseData db = new BaseData(); 

        // GET: api/<AdController>
        [HttpGet]
        public IEnumerable<Anuncios> GetAd([FromBody] Anuncios Ad)
        {
            string sql = $"SELECT * FROM anuncios where idusuario = '{Ad.idusuario}'";
            DataTable dt = db.getTable(sql);
            List<Anuncios> usersList = new List<Anuncios>();
            usersList = (from DataRow dr in dt.Rows
                         select new Anuncios()
                         {
                             idanuncio = Convert.ToInt32(dr["idanuncio"]),
                             idusuario = Convert.ToInt32(dr["idusuario"]),
                             titulo = dr["titulo"].ToString(),
                             descripcion = dr["descripcion"].ToString(),
                             puntuacion = Convert.ToInt32(dr["puntuacion"]),
                             direccion = dr["direccion"].ToString(),
                             estado = dr["estado"].ToString(),
                             tipoEstructura = Convert.ToInt32(dr["tipoEstructura"]),
                             valor = Convert.ToInt32(dr["valor"]),
                             fecha = dr["fecha"].ToString(),
                             certificado = dr["certificado"].ToString()

                         }).ToList();

            return usersList;
        }

        // GET api/<AdController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AdController>
        [HttpPost]
        public string Post([FromBody] Anuncios Ad)
        {
            string sql = $"insert into anuncios (idusuario,titulo,descripcion,puntuacion,direccion,estado,tipoEstructura,valor,fecha,certificado) values('" + Ad.idusuario + "','" + Ad.titulo + "','" + Ad.descripcion + "','" + Ad.puntuacion + "','" + Ad.direccion + "','" + Ad.estado + "','" + Ad.tipoEstructura + "','" + Ad.valor + "','" + Ad.fecha + "','" + Ad.certificado + "');";
            string result = db.executeSql(sql);
            return result;
        }

        // PUT api/<AdController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdController>/5
        [HttpDelete("{id}")]
        public string Delete(int id,[FromBody] Anuncios anuncio)
        {
            string sql = $"Delete * from anuncios where idanuncio = '{id}'";
            string result = db.executeSql(sql);

            return result;
        }
    }
}
