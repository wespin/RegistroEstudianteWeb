import { Registro } from "../../registro/interfaces/registro";

export interface Estudiante {
    estudianteId: number;
    apellido: string;
    nombre: string;
    registros?: Registro[];
}