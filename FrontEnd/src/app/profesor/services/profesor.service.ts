import { Injectable } from '@angular/core';
import { enviroment } from '../../../enviroments/enviroment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../interfaces/api-response';
import { Profesor } from '../interfaces/profesor';

@Injectable({
  providedIn: 'root'
})
export class ProfesorService {

  baseUrl: string = enviroment.apiUrl + 'profesor/';

  constructor(private http: HttpClient) {}

  lista(): Observable<Profesor[]> {
    return this.http.get<Profesor[]>(`${this.baseUrl}`);
  }

  crear(request: Profesor): Observable<Profesor[]> {
    return this.http.post<Profesor[]>(`${this.baseUrl}`, request);
  }

  editar(request: Profesor): Observable<Profesor[]> {
    return this.http.put<Profesor[]>(`${this.baseUrl}${request.profesorId}`,request);
  }  

  eliminar(id: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(`${this.baseUrl}${id}`);
  }  
}
