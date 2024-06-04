import { Injectable } from '@angular/core';
import { enviroment } from '../../../enviroments/enviroment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../interfaces/api-response';
import { Estudiante } from '../interfaces/estudiante';

@Injectable({
  providedIn: 'root'
})
export class EstudianteService {

  baseUrl: string = enviroment.apiUrl + 'estudiante/';

  constructor(private http: HttpClient) {}

  lista(): Observable<Estudiante[]> {
    return this.http.get<Estudiante[]>(`${this.baseUrl}`);
  }

  crear(request: Estudiante): Observable<Estudiante[]> {
    return this.http.post<Estudiante[]>(`${this.baseUrl}`, request);
  }

  editar(request: Estudiante): Observable<Estudiante[]> {
    return this.http.put<Estudiante[]>(`${this.baseUrl}${request.estudianteId}`,request);
  }  

  eliminar(id: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(`${this.baseUrl}${id}`);
  }  
}
