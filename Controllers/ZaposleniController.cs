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
    public class ZaposleniController : ControllerBase
    {
        public AzilContext Context { get; set; }

        public ZaposleniController(AzilContext context)
        {
            Context = context;
        }
        [Route("DodajZaposlenog/{Ime}/{Prezime}/{Adresa}/{JMBG}")]
        [HttpPost]
        public async Task<ActionResult> DodajZaposlenog(string Ime, string Prezime, string Adresa, int JMBG)
        {
            if (string.IsNullOrEmpty(Ime))
            {
                return BadRequest("Niste uneli ime!");
            }
            if (string.IsNullOrEmpty(Prezime))
            {
                return BadRequest("Niste uneli prezime!");
            }
            if (string.IsNullOrEmpty(Adresa))
            {
                return BadRequest("Niste uneli adresu!");
            }
            if (JMBG.ToString().Length != 13)
            {
                return BadRequest("Neispravan JMBG!");
            }
            
            var zap = await Context.Zaposleni.Where(p => p.jmbg == JMBG).FirstOrDefaultAsync();
            if (zap != null)
            {
                return BadRequest("Zaposleni sa unetim JMBG-om vec postoji!");
            }

            try
            {
                Zaposleni zaposleni = new Zaposleni
                { 
                    ime = Ime,
                    prezime = Prezime,
                    adresa = Adresa,
                    jmbg = JMBG
                };
                Context.Zaposleni.Add(zaposleni);
                await Context.SaveChangesAsync();
                return Ok("Novi zaposleni je dodat u bazu podataka!");
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [Route("IzbrisiZaposlenog/{JMBG}/{azilID}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiZaposlenog(long JMBG)
        {
            if(JMBG.ToString().Length != 13)
            {
                return BadRequest("Nepostojeci JMBG!");
            }
            try
            {
                var z = await Context.Zaposleni.Where(p => p.jmbg == JMBG).SingleOrDefaultAsync();
                if (z == null)
                {
                    return BadRequest("Ne postoji zaposleni sa unetim JMBG-om!");
                }
                Context.Zaposleni.Remove(z);
                await Context.SaveChangesAsync();

                return Ok("Zaposleni je uspesno izbrisan iz baze!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }  
        }

        [Route("ProcitajZaposlene/{azil}")]
        [HttpGet]
        public async Task<ActionResult> ProcitajZaposlene(string azil)
        {
            if(string.IsNullOrEmpty(azil))
                {
                    return BadRequest("Niste uneli naziv azila!");
                }
            try
            {
                return Ok(
                    await Context.Zaposleni.Include(p => p.Azil)
                                            .Where(p => p.Azil.naziv == azil)
                                            .Select(p => new {p.ime, p.prezime, p.adresa, p.jmbg})
                                            .ToListAsync()
                         );
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("PrikaziZaposlene/{azilID}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziZaposlene()
        {
            try
            {
                return Ok(await Context.Zaposleni.Select(p => new{
                    p.ime, p.prezime, p.adresa, p.jmbg
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
    }

        [Route("PrikaziZaposlenog")]
        [HttpGet]
        public async Task<ActionResult> PrikaziZaposlenog()
        {
            try
            {
                return Ok(await Context.Zaposleni.Select(p => new{
                    p.ime, p.prezime, p.adresa, p.jmbg
                }).ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
    }
    }
}