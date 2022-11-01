using Agencia_viajar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospedagemController : ControllerBase
    {

        private readonly AgenciaDbContext _context;

        public HospedagemController(AgenciaDbContext context)
        {
            _context = context;
        }

        //POST: CRIA UMA NOVA HOSPEDAGEM
        [HttpPost]
        public IActionResult CriarHospedagem(Hospedagem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Hospedagens.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }

        // GET: api/Hospedagem - LISTA TODOS AS HOSPEDAGENS 
        [HttpGet]
        public IEnumerable<Hospedagem> GetHospedagems()
        {
            return _context.Hospedagens;
        }

        // GET: api/Hospedagem/id - LISTA PASSAGEM POR ID
        [HttpGet("{id}")]
        public IActionResult GetHospedagemPorId(int id)
        {
            Hospedagem item = _context.Hospedagens.SingleOrDefault(modelo => modelo.HospedagemId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //PUT: ATUALIZA UMA HOSPEDAGEM EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaHospedagem(int id, Hospedagem item)
        {
            if (id != item.HospedagemId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //DELETE: DELETAR UMA HOSPEDAGEM POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaHospedagem(int id)
        {
            var item = _context.Hospedagens.SingleOrDefault(modelo => modelo.HospedagemId == id);

            if (item == null)
            {
                return BadRequest();
            }

            _context.Hospedagens.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}
