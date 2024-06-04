import { Curso } from './curso';
export interface Profesor {
    profesorId: number;
    apellido: string;
    nombre: string;
    fechaContratacion: string;
    cursos: Curso[];
  }