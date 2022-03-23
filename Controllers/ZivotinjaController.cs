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
    public class ZivotinjaController : ControllerBase
    {
        public AzilContext Context { get; set; }

        public ZivotinjaController(AzilContext context)
        {
            Context = context;
        }
        [Route("IzbrisiZivotinju/{BrCipa}/{aID}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiZivotinju(int BrCipa, int aID)
        {
            if(BrCipa <= 0)
            {
                return BadRequest("Nepostojeci broj cipa!");
            }
            try
            {
                var z = await Context.Zivotinja.Where(p => p.brCipa == BrCipa || p.Azil.ID == aID)
                                                .FirstOrDefaultAsync();
                if (z == null)
                {
                    return BadRequest("Ne postoji zivotinja sa unetim brojem cipa!");
                }
                Context.Zivotinja.Remove(z);
                await Context.SaveChangesAsync();

                return Ok($"Zivotinja sa brojem cipa {BrCipa} je uspesno udomljena!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }  
        }
        [Route("DodajZivotinju/{Ime}/{brKartona}/{brCipa}")]
        [HttpPost]
        public async Task<ActionResult> DodajZivotinju(string Ime, int brKartona, int brCipa)
        {
            if(string.IsNullOrEmpty(Ime))
            {
                return BadRequest("Niste uneli ime!");
            }
            if(brKartona <= 0)
            {
                return BadRequest("Nepostojeci broj kartona!");
            }
            if(brCipa <= 0)
            {
                return BadRequest("Nepostojeci broj cipa!");
            }
            try
            {
                Zivotinja zivotinja = new Zivotinja
                { 
                    imeZ = Ime,
                    brCipa = brCipa,
                    brKartonaVakc = brKartona
                };
                Context.Zivotinja.Add(zivotinja);
                await Context.SaveChangesAsync();
                return Ok("Nova zivotinja je primljena u azil!");
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }
        [Route("PrikaziVrstuPol/{Vrsta}/{Pol}/{idAzila}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziVrstuPol(string Vrsta, string Pol, int idAzila)
        {
            if(string.IsNullOrEmpty(Vrsta))
            {
                return BadRequest("Niste uneli vrstu!");
            }
            if(string.IsNullOrEmpty(Pol))
            {
                return BadRequest("Niste uneli pol!");
            }
            try
            {
                return Ok(await Context.Zivotinja
                                        .Where(a => a.Cip.polZ== Pol && a.Cip.vrstaZ == Vrsta && a.Azil.ID == idAzila)
                                        .Select(p => new{p.imeZ, p.Cip.brGodina, p.brCipa, p.brKartonaVakc, p.KartonVakcinacije.nazivVakcine, p.KartonVakcinacije.datumVakcinacije})
                                        .ToListAsync());
                                        
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }
        [Route("PrikaziVakcinu/{Vakc}")]
        [HttpGet]
        public async Task<ActionResult> PrikaziVakcinu(string Vakc)
        {
            if(string.IsNullOrEmpty(Vakc))
            {
                return BadRequest("Niste uneli vakcinu!");
            }
            try
            {
                return Ok(await Context.Zivotinja.Include(p => p.KartonVakcinacije)
                                                .Where(p => p.KartonVakcinacije.nazivVakcine == Vakc)
                                                .Select(p => new{p.imeZ, p.brCipa, p.Azil.naziv, p.Azil.kontaktTelefon, p.Azil.email})
                                                .ToListAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("PrikaziZivotinju")]
        [HttpGet]
        public async Task<ActionResult> PrikaziZivotinju()
        {
            try
            {
                return Ok(await Context.Zivotinja.ToListAsync()
                );
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
    }
    }
}