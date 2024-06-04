import { Injectable } from '@angular/core';
import { enviroment } from '../../../enviroments/enviroment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../interfaces/api-response';
import { Registro } from '../interfaces/registro';

@Injectable({
  providedIn: 'root'
})
export class RegistroService {

  baseUrl: string = enviroment.apiUrl + 'registro/';

  constructor(private http: HttpClient) {}

  lista(): Observable<Registro[]> {
    return this.http.get<Registro[]>(`${this.baseUrl}`);
  }

  crear(request: Registro): Observable<Registro[]> {
    return this.http.post<Registro[]>(`${this.baseUrl}`, request);
  }

  editar(request: Registro): Observable<Registro[]> {
    return this.http.put<Registro[]>(`${this.baseUrl}${request.registroId}`,request);
  }  

  eliminar(id: number): Observable<ApiResponse> {
    return this.http.delete<ApiResponse>(`${this.baseUrl}${id}`);
  }  
}
