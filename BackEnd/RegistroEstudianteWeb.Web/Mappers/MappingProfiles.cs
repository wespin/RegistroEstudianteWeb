using AutoMapper;
using RegistroEstudianteWeb.Api.Models;
using RegistroEstudianteWeb.Core.Entities;
using RegistroEstudianteWeb.Web.Models;

namespace RegistroEstudianteWeb.Web.Mappers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Profesor , ProfesorModel>().ReverseMap();
            CreateMap<Profesor, ProfesorSaveModel>();

            CreateMap<ProfesorModel, Profesor>();
            CreateMap<ProfesorSaveModel, Profesor>();

            CreateMap<Estudiante, EstudianteModel>().ReverseMap();
            CreateMap<Estudiante, EstudianteSaveModel>();

            CreateMap<EstudianteModel, Estudiante>();
            CreateMap<EstudianteSaveModel, Estudiante>();

            CreateMap<Curso, CursoModel>().ReverseMap();
            CreateMap<Curso, CursoSaveModel>();

            CreateMap<CursoModel, Curso>();
            CreateMap<CursoSaveModel, Curso>();

            CreateMap<Registro, RegistroModel>().ReverseMap();
            CreateMap<Registro, RegistroSaveModel>();

            CreateMap<RegistroModel, Registro>();
            CreateMap<RegistroSaveModel, Registro>();

            CreateMap<Usuario, UsuarioModel>().ReverseMap();
            CreateMap<Usuario, UsuarioSaveModel>();

            CreateMap<UsuarioModel, Usuario>();
            CreateMap<UsuarioSaveModel, Usuario>();
        }
    }
}
