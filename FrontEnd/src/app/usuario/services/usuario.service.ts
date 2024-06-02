import { Injectable } from '@angular/core';
import { enviroment } from '../../../enviroments/enviroment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sesion } from '../interfaces/sesion';
import { Login } from '../interfaces/login';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseUrl: string = enviroment.apiUrl+"usuario/"
  constructor(private http: HttpClient) { }

  iniciarSesion(request:Login):Observable<Sesion>{
    return this.http.post<Sesion>(`${this.baseUrl}login`, request);
  }
}
