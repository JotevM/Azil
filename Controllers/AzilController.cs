using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AzilController : ControllerBase
    {
        public AzilContext Context { get; set; }

        public AzilController(AzilContext context)
        {
            Context = context;
        }


        [Route("VratiAzile")]
        [HttpGet]
        public async Task<ActionResult> VratiAzile()
        {
            try
            {
                return Ok(
                    await Context.Azil.ToListAsync());
                   // .Select(p => new {p.naziv, p.brZivotinja, p.brZaposlenih, p.kontaktTelefon, p.email}).ToListAsync());
                      
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
    }
}