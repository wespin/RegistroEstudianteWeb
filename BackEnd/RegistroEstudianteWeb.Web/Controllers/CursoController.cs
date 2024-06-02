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
    public class CursoController : Controller
    {
        private readonly ICursoService _CursoService;
        private readonly IMapper _mapper;

        public CursoController(ICursoService CursoService, IMapper mapper)
        {
            _CursoService = CursoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CursoModel>>> Get()
        {
            var Cursoes =
                        await _CursoService.GetAll();

            var mappedCursoes =
                        _mapper.Map<IEnumerable<Curso>, IEnumerable<CursoModel>>(Cursoes);

            return Ok(mappedCursoes);
        }

        // GET api/<CursoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoModel>> Get(int id)
        {
            var Curso = await _CursoService.GetById(id);
            var mappeCurso =
                _mapper.Map<Curso, CursoModel>(Curso);
            return Ok(mappeCurso);
        }

        // POST api/<CursoController>
        [HttpPost]
        public async Task<ActionResult<CursoModel>> Post([FromBody] CursoSaveModel Curso)
        {
            try
            {
                var creadoCurso =
                    await _CursoService.Create(_mapper.Map<CursoSaveModel, Curso>(Curso));

                return Ok(_mapper.Map<Curso, CursoModel>(creadoCurso));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CursoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CursoModel>> Put(int id, [FromBody] CursoSaveModel Curso)
        {
            try
            {
                var modificadoCurso =
                    await _CursoService.Update(id, _mapper.Map<CursoSaveModel, Curso>(Curso));

                return Ok(_mapper.Map<Curso, CursoModel>(modificadoCurso));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CursoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _CursoService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
