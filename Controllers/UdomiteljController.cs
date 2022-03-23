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
    public class UdomiteljController : ControllerBase
    {
        public AzilContext Context { get; set; }

        public UdomiteljController(AzilContext context)
        {
            Context = context;
        }
        [Route("DodajUdomitelja/{Ime}/{Prezime}/{Adresa}/{Tel}/{LK}/{Jmbg}")]
        [HttpPost]
        public async Task<ActionResult> DodajUdomitelja(string nazivAzila, string Ime, string Prezime, string Adresa, string Tel, int LK, int Jmbg)
        {
            if(string.IsNullOrEmpty(nazivAzila))
            {
                return BadRequest("Neispravan naziv azila!");
            }
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
            if (string.IsNullOrEmpty(Tel))
            {
                return BadRequest("Niste uneli broj telefona!");
            }
            if (LK.ToString().Length != 9)
            {
                return BadRequest("Neispravan broj licne karte!");
            }   
            if (Jmbg.ToString().Length != 13)
            {
                return BadRequest("Neispravan maticni broj!");
            } 

            var udom = await Context.Udomitelj.Where(p => p.JMBG == Jmbg).FirstOrDefaultAsync();
            if (udom != null)
            {
                return BadRequest("Udomitelj sa unetim JMBG-om vec postoji!");
            }

            try
            {
                Udomitelj udomitelj = new Udomitelj
                { 
                    imeU = Ime,
                    prezimeU = Prezime,
                    adresaU = Adresa,
                    brTelefonaU = Tel,
                    brLicneKarte = LK,
                    JMBG = Jmbg
                };
                Context.Udomitelj.Add(udomitelj);
                await Context.SaveChangesAsync();
                return Ok("Novi udomitelj je dodat u bazu podataka!");
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 
        }

        [EnableCors("CORS")]
        [Route("DodajUdomiteljaFromBody")]
        [HttpPost]
        public async Task<ActionResult> DodajUdomiteljaFromBody([FromBody] Udomitelj udomitelj)
        {
            if (string.IsNullOrEmpty(udomitelj.imeU))
            {
                return BadRequest("Niste uneli ime!");
            }
            if (string.IsNullOrEmpty(udomitelj.prezimeU))
            {
                return BadRequest("Niste uneli prezime!");
            }
            if (string.IsNullOrEmpty(udomitelj.adresaU))
            {
                return BadRequest("Niste uneli adresu!");
            }
            if (string.IsNullOrEmpty(udomitelj.brTelefonaU))
            {
                return BadRequest("Niste uneli broj telefona!");
            }
            if (udomitelj.brLicneKarte.ToString().Length != 9)
            {
                return BadRequest("Neispravan broj licne karte!");
            }   
            if (udomitelj.JMBG.ToString().Length != 13)
            {
                return BadRequest("Neispravan maticni broj!");
            } 

            try{
                Context.Udomitelj.Add(udomitelj);
                await Context.SaveChangesAsync();
                return Ok($"Dodat je udomitelj sa ID-jem: {udomitelj.ID}");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("ProcitajUdomitelja/{brLK}")]
        [HttpGet]
        public async Task<ActionResult> ProcitajUdomitelja(int brLK)
        {
            if(brLK.ToString().Length != 9)
                {
                    return BadRequest("Niste uneli postojeci broj licne karte!");
                }
            try
            {
                return Ok(
                    await Context.Udomitelj.Where(p => p.brLicneKarte == brLK)
                                            .Include(pa => pa.Zivotinje)
                                            .Select(p => new {p.imeU, p.prezimeU, p.adresaU, p.Zivotinje}).ToListAsync()
                         );
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("ProcitajUdomljeneZ/{brLK}")]
        [HttpGet]
         public async Task<ActionResult> ProcitajUdomljeneZ(int brLK)
        {
            if(brLK.ToString().Length != 9)
                {
                    return BadRequest("Niste uneli postojeci broj licne karte!");
                }
            try
            {
                return Ok(
                    await Context.Zivotinja.Where(p => p.Udomitelj.brLicneKarte == brLK)
                                            .Select(z => new{z.imeZ, z.brCipa}).ToArrayAsync()
                         );
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }
        [Route("PrijaviteSe/{brLK}/{Jmbg}")]
        [HttpGet]
        public async Task<ActionResult> PrijaviteSe(int brLK, int Jmbg)
        {
            if(brLK.ToString().Length != 9)
              {
                return BadRequest("Neispravan broj licne karte!");
              }  
            if(Jmbg.ToString().Length != 13)
              {
                return BadRequest("Neispravan JMBG!");
              }
          
            try{
                var udomitelj=await Context.Udomitelj.Where(p =>p.JMBG == Jmbg).FirstOrDefaultAsync();
                if(udomitelj==null)
                    return BadRequest("Korisnik sa unetim JMBG-om ne postoji!");   
                if(udomitelj.brLicneKarte!=brLK)
                    return BadRequest("Unet je pogresan broj licne karte!");  
                
                return Ok(udomitelj);   
            }
            catch(Exception e){
                return BadRequest(e.Message);
            }
         
        }

        [Route("PrikaziUdomitelje")]
        [HttpGet]
        public async Task<ActionResult> PrikaziUdomitelje()
        {
            try
            {
                return Ok(await Context.Udomitelj.ToListAsync() //.Select(p => new{
                    //p.imeU, p.prezimeU, p.adresaU, p.brTelefonaU, p.brLicneKarte, p.JMBG
            // }          
         );//.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
    }

    }
}