using Agencia_viajar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassagemController : ControllerBase
    {

        private readonly AgenciaDbContext _context;

        public PassagemController(AgenciaDbContext context)
        {
            _context = context;
        }

        //POST: CRIA UMA NOVA PASSAGEM
        [HttpPost]
        public IActionResult CriarPassagem(Passagem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Passagens.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }

        // GET: api/Passagem - LISTA TODOS AS PASSAGENS 
        [HttpGet]
        public IEnumerable<Passagem> GetPassagems()
        {
            return _context.Passagens;
        }

        // GET: api/Passagem/id - LISTA PASSAGEM POR ID
        [HttpGet("{id}")]
        public IActionResult GetPassagemPorId(int id)
        {
            Passagem item = _context.Passagens.SingleOrDefault(modelo => modelo.PassagemId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //PUT: ATUALIZA UMA PASSAGEM EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaPassagem(int id, Passagem item)
        {
            if (id != item.PassagemId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //DELETE: DELETAR UMA PASSAGEM POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaPassagem(int id)
        {
            var item = _context.Passagens.SingleOrDefault(modelo => modelo.PassagemId == id);

            if (item == null)
            {
                return BadRequest();
            }

            _context.Passagens.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }


    }
}
