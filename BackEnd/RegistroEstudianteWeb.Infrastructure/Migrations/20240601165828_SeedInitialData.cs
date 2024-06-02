using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

#nullable disable

namespace RegistroEstudianteWeb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
              .Sql("INSERT INTO Estudiante (Nombre, Apellido, FechaRegistro) VALUES ('Juan', 'Perez', '2024-06-01');");
            migrationBuilder
              .Sql("INSERT INTO Estudiante (Nombre, Apellido, FechaRegistro) VALUES ('Maria', 'Lopez', '2024-06-01');");
            migrationBuilder
              .Sql("INSERT INTO Estudiante (Nombre, Apellido, FechaRegistro) VALUES ('Pedro', 'Gomez', '2024-06-01');");
            migrationBuilder
              .Sql("INSERT INTO Estudiante (Nombre, Apellido, FechaRegistro) VALUES ('Ana', 'Martinez', '2024-06-01');");
            migrationBuilder
              .Sql("INSERT INTO Estudiante (Nombre, Apellido, FechaRegistro) VALUES ('Luis', 'Rodriguez', '2024-06-01');");


            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(1000, 'Matematicas', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(2000, 'Fisica', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(3000, 'Quimica', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(4000, 'Biologia', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(5000, 'Historia', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(6000, 'Geografia', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(7000, 'Ingles', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(8000, 'Frances', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(9000, 'Italiano', 3);");
            migrationBuilder
              .Sql("INSERT INTO Curso(CursoId,Nombre, Creditos) VALUES(1100, 'Portugues', 3);");


            migrationBuilder
                .Sql("INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(1, 1000, 0);");
            migrationBuilder
                .Sql("INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(1, 2000, 0);");
            migrationBuilder
                .Sql("INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(2, 1000, 0);");



            migrationBuilder
                .Sql("INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(1, 1000, 0);");
            migrationBuilder
                .Sql("INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(1, 2000, 0);");
            migrationBuilder
                .Sql("INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(2, 1000, 0);");




            migrationBuilder
                .Sql("INSERT INTO Profesor (Nombre, Apellido, FechaContratacion) VALUES ('Carlos', 'Gonzalez', '2024-06-01');");
            migrationBuilder
                .Sql("INSERT INTO Profesor (Nombre, Apellido, FechaContratacion) VALUES ('Laura', 'Garcia', '2024-06-01');");
            migrationBuilder
                .Sql("INSERT INTO Profesor (Nombre, Apellido, FechaContratacion) VALUES ('Sofia', 'Perez', '2024-06-01');");
            migrationBuilder
                .Sql("INSERT INTO Profesor (Nombre, Apellido, FechaContratacion) VALUES ('Jorge', 'Gomez', '2024-06-01');");    

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
