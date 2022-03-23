using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CipController : ControllerBase
    {
        public AzilContext Context { get; set; }

        public CipController(AzilContext context)
        {
            Context = context;
        }

        [EnableCors("CORS")]
        [Route("DodajCip/{Ime}/{pol}/{starost}/{vrsta}/{id}")]
        [HttpPost]
        public async Task<ActionResult> DodajCip(string Ime, string pol, int starost, string vrsta)
        {
            if (string.IsNullOrEmpty(Ime))
            {
                return BadRequest("Niste uneli ime!");
            }
            if (string.IsNullOrEmpty(pol))
            {
                return BadRequest("Niste uneli pol!");
            }
            // if(ID <= 0)
            //{
             //   return BadRequest("Ne postojeci ID!");
           // }
            if (starost <= 0)
            {
                return BadRequest("Pogresan broj godina!");
            }
            if (string.IsNullOrEmpty(vrsta))
            {
                return BadRequest("Niste uneli vrstu!");
            }

            try
            {   
                var ime = await Context.Zivotinja.Where(p => p.imeZ == Ime) //&& p.ID == ID)
                                            .FirstOrDefaultAsync();
                if (ime == null)
                {
                    return BadRequest("Zivotinja sa trazenim imenom ne postoji!");
                }
                Cip cip = new Cip
                {
                    polZ = pol,
                    brGodina = starost,
                    vrstaZ = vrsta
                };

                Context.Cip.Add(cip);
                await Context.SaveChangesAsync();

                return Ok($"Cipovan/a je {vrsta} sa imenom {Ime}, pola {pol}, starosti {starost} godina.");       
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [Route("PrikaziCip")]
        [HttpGet]
        public async Task<ActionResult> PrikaziCip()
        {
            try{

                return Ok(
                    await Context.Cip.ToListAsync()
                );

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}