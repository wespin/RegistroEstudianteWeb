CREATE DATABASE [RegistroEstudianteWeb]
GO

USE [RegistroEstudianteWeb]
GO

CREATE TABLE [dbo].[Curso](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Creditos] [int] NOT NULL,
 CONSTRAINT [PK_Curso] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Estudiante](
	[EstudianteId] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Estudiante] PRIMARY KEY CLUSTERED 
(
	[EstudianteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Profesor](
	[ProfesorId] [int] IDENTITY(1,1) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[FechaContratacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Profesor] PRIMARY KEY CLUSTERED 
(
	[ProfesorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Registro](
	[RegistroId] [int] IDENTITY(1,1) NOT NULL,
	[CursoId] [int] NOT NULL,
	[EstudianteId] [int] NOT NULL,
	[Nota] [int] NULL,
 CONSTRAINT [PK_Registro] PRIMARY KEY CLUSTERED 
(
	[RegistroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CursoProfesor](
	[CursoId] [int] NOT NULL,
	[ProfesorId] [int] NOT NULL,
 CONSTRAINT [PK_CursoProfesor] PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC,
	[ProfesorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




ALTER TABLE [dbo].[CursoProfesor]  WITH CHECK ADD  CONSTRAINT [FK_CursoProfesor_Curso_CursoId] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursoProfesor] CHECK CONSTRAINT [FK_CursoProfesor_Curso_CursoId]
GO
ALTER TABLE [dbo].[CursoProfesor]  WITH CHECK ADD  CONSTRAINT [FK_CursoProfesor_Profesor_ProfesorId] FOREIGN KEY([ProfesorId])
REFERENCES [dbo].[Profesor] ([ProfesorId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CursoProfesor] CHECK CONSTRAINT [FK_CursoProfesor_Profesor_ProfesorId]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Curso_CursoId] FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_Curso_CursoId]
GO
ALTER TABLE [dbo].[Registro]  WITH CHECK ADD  CONSTRAINT [FK_Registro_Estudiante_EstudianteId] FOREIGN KEY([EstudianteId])
REFERENCES [dbo].[Estudiante] ([EstudianteId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Registro] CHECK CONSTRAINT [FK_Registro_Estudiante_EstudianteId]
GO

INSERT INTO Curso(Nombre, Creditos) VALUES('Matematicas', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Fisica', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Quimica', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Biologia', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Historia', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Geografia', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Ingles', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Frances', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Italiano', 3)
INSERT INTO Curso(Nombre, Creditos) VALUES('Portugues', 3)

INSERT INTO Estudiante (Nombre, Apellido, FechaRegistro) VALUES ('Juan', 'Perez', '2024-06-01')
INSERT INTO Estudiante (Nombre, Apellido, FechaRegistro) VALUES ('Maria', 'Lopez', '2024-06-01')

INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(1, 1, 0)
INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(1, 2, 0)
INSERT INTO Registro(EstudianteId, CursoId, Nota) VALUES(1, 1, 0)

INSERT INTO CursoProfesor(CursoId, ProfesorId) VALUES(1, 1)
INSERT INTO CursoProfesor(CursoId, ProfesorId) VALUES(2, 1)

INSERT INTO Profesor(Apellido, Nombre, FechaContratacion) VALUES('PEREZ', 'WILFREDO', '2024-04-22')
INSERT INTO Profesor(Apellido, Nombre, FechaContratacion) VALUES('CADENA', 'ALAN', '2024-04-22')
INSERT INTO Profesor(Apellido, Nombre, FechaContratacion) VALUES('TORRES', 'STEVE', '2024-04-22')
INSERT INTO Profesor(Apellido, Nombre, FechaContratacion) VALUES('GONZALEZ', 'MINERVA', '2024-04-22')
INSERT INTO Profesor(Apellido, Nombre, FechaContratacion) VALUES('LOPEZ', 'BENITO', '2024-04-22')

SELECT * FROM [RegistroEstudianteWeb].[dbo].[CursoProfesor]
SELECT * FROM [RegistroEstudianteWeb].[dbo].[Curso]
SELECT * FROM [RegistroEstudianteWeb].[dbo].[Profesor]
SELECT * FROM [RegistroEstudianteWeb].[dbo].[Registro]
SELECT * FROM [RegistroEstudianteWeb].[dbo].Estudiante

