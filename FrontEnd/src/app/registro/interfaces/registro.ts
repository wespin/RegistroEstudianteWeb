import { Curso } from "../../curso/interfaces/curso";
import { Estudiante } from "../../estudiante/interfaces/estudiante";

export interface Registro {
    registroId: number;
    cursoId: string;
    estudianteId: string;
    cursos: Curso[];
    estudiantes: Estudiante[];
}