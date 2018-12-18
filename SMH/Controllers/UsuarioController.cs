using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMH.Models.DTOs.UsuarioDTOs;
using SMH.Models.Repositorios;
using SMH.Models.Requests;
using SMH.Models.ServiciosDeAplicacion;

namespace SMH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioAppService _usuarioAppService;
        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
           if(usuarioAppService == null) throw new ArgumentNullException(nameof(usuarioAppService));

            _usuarioAppService = usuarioAppService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDTO>> Get()
        {
            return _usuarioAppService.ObtenerUsuarios().ToList();
        }

        // [HttpGet("{id}", Name = "GetUsuario")]
        [HttpGet("{id}")]
        public UsuarioDTO Get([FromBody]UsuarioRequest request)
        {
            return _usuarioAppService.ObtenerUsuario(request);
        }

        // POST api/values
        [HttpPost]
        public UsuarioDTO Post([FromBody] UsuarioRequest request)
        {
            return _usuarioAppService.CrearUsuario(request);
        }
    }
}