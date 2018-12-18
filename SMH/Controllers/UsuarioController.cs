using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMH.Models.Entidades.UsuarioEntidades;
using SMH.Models.Infraestructura;
using SMH.Models.Repositorios;

namespace SMH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IRepositorioGenerico<Usuario> _usuarioRepositorio;
        public UsuarioController(IRepositorioGenerico<Usuario> usuarioRepositorio)
        {
           if(usuarioRepositorio == null) throw new ArgumentNullException(nameof(usuarioRepositorio));

           _usuarioRepositorio = usuarioRepositorio;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            return _usuarioRepositorio.GetAll().ToList();
        }
    }
}