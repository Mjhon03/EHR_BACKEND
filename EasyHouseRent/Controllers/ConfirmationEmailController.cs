﻿using EasyHouseRent.Model;
using EasyHouseRent.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public bool Get([FromBody] Usuarios user)
        {
            string sql = $"SELECT email FROM usuarios where email = '{user.email}';";

            db.ConfirmationEmial(sql);
            return db.ConfirmationEmial(sql);
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