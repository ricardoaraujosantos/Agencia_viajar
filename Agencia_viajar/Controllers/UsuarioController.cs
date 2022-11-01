using Agencia_viajar.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agencia_viajar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly AgenciaDbContext _context;

        public UsuarioController(AgenciaDbContext context)
        {
            _context = context;
        }

        //POST: CRIA UM NOVO USUARIO
        [HttpPost]
        public IActionResult CriarUsuario(Usuario item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Usuarios.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }

        // GET: api/Usuario - LISTA TODOS OS USUARIOS 
        [HttpGet]
        public IEnumerable<Usuario> GetUsuarios()
        {
            return _context.Usuarios;
        }

        // GET: api/Usuario/id - LISTA USUARIO POR ID
        [HttpGet("{id}")]
        public IActionResult GetUsuarioPorId(int id)
        {
            Usuario item = _context.Usuarios.SingleOrDefault(modelo => modelo.UsuarioId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        //PUT: ATUALIZA UM USUARIO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaUsuario(int id, Usuario item)
        {
            if (id != item.UsuarioId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        //DELETE: DELETAR UM USUARIO POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaUsuario(int id)
        {
            var item = _context.Usuarios.SingleOrDefault(modelo => modelo.UsuarioId == id);

            if (item == null)
            {
                return BadRequest();
            }

            _context.Usuarios.Remove(item);
            _context.SaveChanges();
            return Ok(item);
        }
    }
}
