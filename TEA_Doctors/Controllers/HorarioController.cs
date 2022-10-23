using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEA_Doctors.Context;
using TEA_Doctors.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TEA_Doctors.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly AppDBContext context;

        public HorarioController(AppDBContext context)
        {
            this.context = context;
        }





        // GET: api/<HorarioController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Horario.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // GET api/<HorarioController>/5
        [HttpGet("{id}", Name = "GetHorario")]
        public ActionResult Get(int id)
        {
            try
            {
                var Horario = context.Horario.FirstOrDefault(h => h.ID_horario == id);
                return Ok(Horario);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        // POST api/<HorarioController>
        [HttpPost]
        public ActionResult Post([FromBody] Horario horario)
        {
            try
            {
                context.Horario.Add(horario);
                context.SaveChanges();
                return CreatedAtRoute("GetHorario", new { id = horario.ID_horario }, horario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // PUT api/<HorarioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Horario horario)
        {
            try
            {
                if (horario.ID_horario == id)
                {
                    context.Entry(horario).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetHorario", new { id = horario.ID_horario }, horario);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




        // DELETE api/<HorarioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Horario = context.Horario.FirstOrDefault(h => h.ID_horario == id);
                if (Horario != null)
                {
                    context.Horario.Remove(Horario);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
