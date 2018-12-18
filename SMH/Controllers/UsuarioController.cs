using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Infraestructura;

namespace SMH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController(UnitOfWork context)
        {
            _context = context;
        }
        private readonly UnitOfWork _context;
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return _context.Usuario;
        }
    }
}