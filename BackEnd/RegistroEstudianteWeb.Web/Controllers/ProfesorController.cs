using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegistroEstudianteWeb.Core.Interfaces.Services;
using RegistroEstudianteWeb.Web.Models;
using RegistroEstudianteWeb.Core.Entities;
using RegistroEstudianteWeb.Api.Models;
using System.Net;

namespace RegistroEstudianteWeb.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesorService _profesorService;
        private readonly IMapper _mapper;
        private ApiResponse _response;

        public ProfesorController(IProfesorService profesorService, IMapper mapper)
        {
            _profesorService = profesorService;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfesorModel>>> Get()
        {
            var profesores = await _profesorService.GetAll();

            var mappedProfesores =
                        _mapper.Map<IEnumerable<Profesor>, IEnumerable<ProfesorModel>>(profesores);

            return Ok(mappedProfesores);
        }

        // GET api/<ProfesorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfesorModel>> Get(int id)
        {
            var profesor = await _profesorService.GetById(id);
            var mappeProfesor =
                _mapper.Map<Profesor, ProfesorModel>(profesor);
            return Ok(mappeProfesor);
        }

        // POST api/<ProfesorController>
        [HttpPost]
        public async Task<ActionResult<ProfesorModel>> Post([FromBody] ProfesorSaveModel profesor)
        {
            try
            {
                var creadoProfesor =
                    await _profesorService.Create(_mapper.Map<ProfesorSaveModel, Profesor>(profesor));

                return Ok(_mapper.Map<Profesor, ProfesorModel>(creadoProfesor));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProfesorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProfesorModel>> Put(int id, [FromBody] ProfesorSaveModel profesor)
        {
            try
            {
                var modificadoProfesor =
                    await _profesorService.Update(id, _mapper.Map<ProfesorSaveModel, Profesor>(profesor));

                return Ok(_mapper.Map<Profesor, ProfesorModel>(modificadoProfesor));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProfesorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                 await _profesorService.Delete(id);
                
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;

                return BadRequest(_response);
            }
        }
    }
}
