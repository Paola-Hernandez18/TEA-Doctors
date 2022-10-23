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
    public class MedicamentoController : ControllerBase
    {
        //Traemos contexto de datos
        private readonly AppDBContext context;


        //Creamos constructor
        public MedicamentoController(AppDBContext context)
        {
            this.context = context;
        }


        //------------------------------------ Traer todos los datos -----------------------

        // GET: api/<MedicamentoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Medicamento.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //------------------------------------ Traer un solo dato -----------------------

        // GET api/<MedicamentoController>/5
        [HttpGet("{id}", Name = "GetMedicamento")]
        public ActionResult Get(int id)
        {
            try
            {
                var Medicamento = context.Medicamento.FirstOrDefault(m => m.ID_medicamento == id);
                return Ok(Medicamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //------------------------------------ Guardar registro nuevo -----------------------

        // POST api/<MedicamentoController>
        [HttpPost]
        public ActionResult Post([FromBody] Medicamento medicamento)
        {
            try
            {
                context.Medicamento.Add(medicamento);
                context.SaveChanges();
                return CreatedAtRoute("GetMedicamento", new { id = medicamento.ID_medicamento }, medicamento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }






        // PUT api/<MedicamentoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Medicamento medicamento)
        {
            try
            {
                if (medicamento.ID_medicamento == id)
                {
                    context.Entry(medicamento).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetMedicamento", new { id = medicamento.ID_medicamento }, medicamento);
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



        //------------------------------------- Eliminar Registro ----------------------------------

        // DELETE api/<MedicamentoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var Medicamento = context.Medicamento.FirstOrDefault(m => m.ID_medicamento == id);
                if (Medicamento != null)
                {
                    context.Medicamento.Remove(Medicamento);
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
