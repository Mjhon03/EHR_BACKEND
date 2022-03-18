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
    public class MunicipalityController : ControllerBase
    {
        BaseData db = new BaseData();
        // GET: api/<MunicipalityController>
        [HttpGet]
        public IEnumerable<Municipios> Get()
        {
            string sql = "SELECT * FROM municipios WHERE nombre != 'desconocido'";
            DataTable dt = db.getTable(sql);
            List<Municipios> MunicipioList = new List<Municipios>();
            MunicipioList = (from DataRow dr in dt.Rows
                         select new Municipios()
                         {
                             idmunicipio = Convert.ToInt32(dr["idmunicipio"]),
                             nombre = dr["nombre"].ToString(),
                             departamento = Convert.ToInt32(dr["departamento"]),
                         }).ToList();

            return MunicipioList;
        }

        // GET api/<MunicipalityController>/5
        [HttpGet("{nombreDepartamento}")]
        [Route("api/Municipality/{nombreDepartamento}")]
        public IEnumerable<Municipios>Get([FromQuery]string nombreDepartamento)
        {
            string sql = $"select m.nombre FROM municipios m INNER JOIN departamento d on m.departamento=d.iddepartamento where d.nombre = '{nombreDepartamento}'";
            DataTable dt = db.getTable(sql);
            List<Municipios> MunicipioList = new List<Municipios>();
            MunicipioList = (from DataRow dr in dt.Rows
                             select new Municipios()
                             {
                                 nombre = dr["nombre"].ToString()
                             }).ToList();
            return MunicipioList;
        }

        // POST api/<MunicipalityController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<MunicipalityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MunicipalityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
