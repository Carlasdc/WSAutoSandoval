using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WSAuto.Data;
using WSAuto.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSAuto.Controllers
{
    [Route("api/auto")]
    [ApiController]
    public class WSAutoController : ControllerBase
    {
        private readonly DBAutoAPIContext context;
        public WSAutoController(DBAutoAPIContext context)
        {
            this.context = context;
        }

        // GET: api/<WSAutoController>
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            List<Auto> autos = (from a in context.Autos
                                select a).ToList();
            return autos;
        }

        // GET api/<WSAutoController>/
        [HttpGet("{id}")]
        public Auto Get(int id)
        {
            //EF
            Auto auto = context.Autos.Find(id);

            return auto;

        }

        [HttpGet("modelo")]
        public Auto Get(string modelo)
        {
            var autos = (from a in context.Autos
                             where a.Modelo == modelo
                             select a).SingleOrDefault();
            return autos;
        }

        [HttpGet("{marca}/{modelo}/{color}")]
        public dynamic Get(string marca, string modelo, string color)
        {
            dynamic autos = (from a in context.Autos
                             where a.Marca == marca && a.Modelo == modelo && a.Color == color
                             select new { a.Color});
            return autos;

        }

        [HttpGet("{marca}/{modelo}")]
        public dynamic Get(string marca, string modelo)
        {
            dynamic autos = (from a in context.Autos
                                 where a.Marca == marca && a.Modelo == modelo
                                 select new { a.Marca, a.Modelo});
            return autos;

        }

        // POST api/<WSAutoController>
        [HttpPost]
        public ActionResult Post(Auto auto)
        {
            //EF -- memoria
            context.Autos.Add(auto);
            //EF - Guardar en la DB
            context.SaveChanges();

            return Ok();

        }

        // PUT api/<WSAutoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Auto auto)
        {
            if (id != auto.Id)
            {
                return BadRequest();
            }

            //EF para modificar en la DB
            context.Entry(auto).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }

        // DELETE api/<WSAutoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            //EF
            var auto = context.Autos.Find(id);

            if (auto == null)
            {
                return NotFound();
            }

            //EF
            context.Autos.Remove(auto);
            context.SaveChanges();

            return NoContent();

        }
    }
}
