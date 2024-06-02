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
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService _EstudianteService;
        private readonly IMapper _mapper;

        public EstudianteController(IEstudianteService EstudianteService, IMapper mapper)
        {
            _EstudianteService = EstudianteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstudianteModel>>> Get()
        {
            var Estudiantees =
                        await _EstudianteService.GetAll();

            var mappedEstudiantees =
                        _mapper.Map<IEnumerable<Estudiante>, IEnumerable<EstudianteModel>>(Estudiantees);

            return Ok(mappedEstudiantees);
        }

        // GET api/<EstudianteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EstudianteModel>> Get(int id)
        {
            var Estudiante = await _EstudianteService.GetById(id);
            var mappeEstudiante =
                _mapper.Map<Estudiante, EstudianteModel>(Estudiante);
            return Ok(mappeEstudiante);
        }

        // POST api/<EstudianteController>
        [HttpPost]
        public async Task<ActionResult<EstudianteModel>> Post([FromBody] EstudianteSaveModel Estudiante)
        {
            try
            {
                var creadoEstudiante =
                    await _EstudianteService.Create(_mapper.Map<EstudianteSaveModel, Estudiante>(Estudiante));

                return Ok(_mapper.Map<Estudiante, EstudianteModel>(creadoEstudiante));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<EstudianteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EstudianteModel>> Put(int id, [FromBody] EstudianteSaveModel Estudiante)
        {
            try
            {
                var modificadoEstudiante =
                    await _EstudianteService.Update(id, _mapper.Map<EstudianteSaveModel, Estudiante>(Estudiante));

                return Ok(_mapper.Map<Estudiante, EstudianteModel>(modificadoEstudiante));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<EstudianteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _EstudianteService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
