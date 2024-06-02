using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistroEstudianteWeb.Core.Entities;
using RegistroEstudianteWeb.Core.Interfaces.Services;
using RegistroEstudianteWeb.Web.Models;

namespace RegistroEstudianteWeb.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegistroController : Controller
    {
        private readonly IRegistroService _RegistroService;
        private readonly IMapper _mapper;

        public RegistroController(IRegistroService RegistroService, IMapper mapper)
        {
            _RegistroService = RegistroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroModel>>> Get()
        {
            var Registroes =
                        await _RegistroService.GetAll();

            var mappedRegistroes =
                        _mapper.Map<IEnumerable<Registro>, IEnumerable<RegistroModel>>(Registroes);

            return Ok(mappedRegistroes);
        }

        // GET api/<RegistroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroModel>> Get(int id)
        {
            var Registro = await _RegistroService.GetById(id);
            var mappeRegistro =
                _mapper.Map<Registro, RegistroModel>(Registro);
            return Ok(mappeRegistro);
        }

        // POST api/<RegistroController>
        [HttpPost]
        public async Task<ActionResult<RegistroModel>> Post([FromBody] RegistroSaveModel Registro)
        {
            try
            {
                var creadoRegistro =
                    await _RegistroService.Create(_mapper.Map<RegistroSaveModel, Registro>(Registro));

                return Ok(_mapper.Map<Registro, RegistroModel>(creadoRegistro));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RegistroController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RegistroModel>> Put(int id, [FromBody] RegistroSaveModel Registro)
        {
            try
            {
                var modificadoRegistro =
                    await _RegistroService.Update(id, _mapper.Map<RegistroSaveModel, Registro>(Registro));

                return Ok(_mapper.Map<Registro, RegistroModel>(modificadoRegistro));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RegistroController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _RegistroService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
