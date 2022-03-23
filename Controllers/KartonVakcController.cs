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
    public class KartonVakcController : ControllerBase
    {
        public AzilContext Context { get; set; }

        public KartonVakcController(AzilContext context)
        {
            Context = context;
        }
        [Route("Revakcina/{Ime}/{Datum}/{NazivVakc}/{id}")]
        [HttpPut]
        public async Task<ActionResult> PromeniKarton(string Ime, string Datum, string NazivVakc)
        {
            if (string.IsNullOrEmpty(Ime))
            {
                return BadRequest("Niste uneli ime!");
            }
            if (string.IsNullOrEmpty(Datum))
            {
                return BadRequest("Niste uneli datum!");
            }
            if (string.IsNullOrEmpty(NazivVakc))
            {
                return BadRequest("Niste uneli naziv vakcine!");
            }
            try
            {
                var dat = DateTime.ParseExact(Datum, "dd.MM.yyyy.", null);
                var v = await Context.Zivotinja.Where(p => p.imeZ == Ime).FirstOrDefaultAsync();
                if (v == null)
                {
                    return BadRequest("Zivotinja sa trazenim imenom ne postoji!");
                }
                var datum = await Context.KartonVakcinacije.Where(p => p.nazivVakcine == NazivVakc).FirstOrDefaultAsync();
                datum.datumVakcinacije = dat;
                Context.KartonVakcinacije.Update(datum);

                await Context.SaveChangesAsync();
                return Ok($"Uspesna revakcinacija datuma: {Datum}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }     
        }

        [Route("PrikaziVakcine/{BrKartona}")]
        [HttpGet]
         public async Task<ActionResult> PrikaziVakcine(int BrKartona)
        {
            if (BrKartona <= 0)
            {
                return BadRequest("Niste uneli broj kartona!");
            }
             try
            {
              return Ok(await Context.Zivotinja.Where(p => p.brKartonaVakc == BrKartona)
                                    .Select(p => new{p.KartonVakcinacije.nazivVakcine, p.KartonVakcinacije.datumVakcinacije})
                                    .ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }     
        }

        [Route("PrikaziKarton")]
        [HttpGet]
        public async Task<ActionResult> PrikaziKarton()
        {
            try
            {
                return Ok(await Context.KartonVakcinacije.Select(p => new{
                    p.nazivVakcine, p.datumVakcinacije
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
    }
    }
}
