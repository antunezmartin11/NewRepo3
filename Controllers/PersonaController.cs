using Microsoft.AspNetCore.Mvc;
using Prueba.Contexto;
using Prueba.Models;
using Microsoft.EntityFrameworkCore;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<PersonaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Persona>>> Get()
        {
            return await _context.personas.ToListAsync();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Persona>> getId(int id) 
        {
            var persona = await _context.personas.FindAsync(id);
            if(persona == null)
                {
                    return NotFound();
                }
            return persona;
        }
            
        // POST api/<PersonaController>
        [HttpPost]
        public async Task<ActionResult<Persona>> guardarPersona(Persona persona) {
            _context.personas.Add(persona);
            await _context.SaveChangesAsync();

            return Ok(persona);
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> updatePersona(int id, Persona persona) 
        {
            var persona1 = await _context.personas.FindAsync(id);

            if(persona1 == null)
            {
                return NotFound();
            }
            _context.Entry(persona1).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(persona1);
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona(int id) 
        {
            var persona = await _context.personas.FindAsync(id);
            if(persona == null)
            {
                return NotFound();
            }
            _context.personas.Remove(persona);
            await _context.SaveChangesAsync();
            return Ok(persona);
        }
    }
}
