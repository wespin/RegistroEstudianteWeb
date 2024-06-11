using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroEstudianteWeb.Api.Models;
using RegistroEstudianteWeb.Core.Entities;
using RegistroEstudianteWeb.Core.Interfaces.Services;
using RegistroEstudianteWeb.Services;
using RegistroEstudianteWeb.Web.Models;
using System.Security.Cryptography;
using System.Text;

namespace RegistroEstudianteWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        private readonly IUsuarioService _UsuarioService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UsuarioController(IUsuarioService UsuarioService, IMapper mapper, ITokenService tokenService)
        {
            _UsuarioService = UsuarioService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> Get()
        {
            var Usuarios =
                        await _UsuarioService.GetAll();

            var mappedUsuarios =
                        _mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioModel>>(Usuarios);

            return Ok(mappedUsuarios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> Get(int id)
        {
            var Usuario = await _UsuarioService.GetById(id);
            var mappeUsuario =
                _mapper.Map<Usuario, UsuarioModel>(Usuario);
            return Ok(mappeUsuario);
        }

        // POST api/<RegistroController>
        [HttpPost("Registro")]
        public async Task<ActionResult<UsuarioTokenModel>> Post([FromBody] UsuarioSaveModel Usuario)
        {
            try
            {
                if (await UsuarioExiste(Usuario.NombreUsuario))
                {
                    return BadRequest("El nombre de usuario ya existe");
                }

                using var hmac = new HMACSHA512();

                var usuario = new Usuario
                {
                    NombreUsuario = Usuario.NombreUsuario.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Usuario.Password)),
                    PasswordSalt = hmac.Key
                };

                var creadoUsuario =
                    await _UsuarioService.Create(usuario);

                //return Ok(_mapper.Map<Usuario, UsuarioModel>(creadoUsuario));
                return Ok(new UsuarioTokenModel
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Token = _tokenService.CrearToken(usuario)
                });
                            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioTokenModel>> Login(UsuarioSaveModel Usuario)
        {
            try
            {
               var usuario = await _UsuarioService.GetByNombreUsuario(Usuario.NombreUsuario);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
                if (usuario == null)
                {
                    return Unauthorized("Usuario no valido");
                }
                using var hmac = new HMACSHA512(usuario.PasswordSalt);
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Usuario.Password));

                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != usuario.PasswordHash[i])
                    {
                        return Unauthorized("Password no valida");
                    }
                }

                //var mappeUsuario =
                //              _mapper.Map<UsuarioModel>(usuario);

                //return Ok(mappeUsuario);
                return Ok(new UsuarioTokenModel
                {
                    NombreUsuario = usuario.NombreUsuario,
                    Token = _tokenService.CrearToken(usuario)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<bool> UsuarioExiste(string NombreUsuario)
        {

            var Usuarios = await _UsuarioService.GetAll();
            foreach (var Usuario in Usuarios)
            {
                if (Usuario.NombreUsuario.ToLower() == NombreUsuario.ToLower())
                {
                    return true;
                }
            }
            return false;}
    }
}
