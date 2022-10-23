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
    public class FormulaController : ControllerBase
    {

        private readonly AppDBContext context;

        public FormulaController(AppDBContext context)
        {
            this.context = context;
        }



        // GET: api/<FormulaController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Formula.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<FormulaController>/5
        [HttpGet("{id}", Name = "GetFormula")]
        public ActionResult Get(int id)
        {
            try
            {
                var formula = context.Formula.FirstOrDefault(f => f.ID_formula == id);
                return Ok(formula);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //post = agregar y put = modificar

        // POST api/<FormulaController>
        [HttpPost]
        public ActionResult Post([FromBody] Formula formula)
        {
            try
            {
                context.Formula.Add(formula);
                context.SaveChanges();
                return CreatedAtRoute("GetFormula", new { id = formula.ID_formula }, formula);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FormulaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Formula formula)
        {
            try
            {
                if (formula.ID_formula == id)
                {
                    context.Entry(formula).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetFormula", new { id = formula.ID_formula }, formula);
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

        // DELETE api/<FormulaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var formula = context.Formula.FirstOrDefault(f => f.ID_formula == id);
                if (formula != null)
                {
                    context.Formula.Remove(formula);
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
