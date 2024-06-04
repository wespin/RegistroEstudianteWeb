import { Injectable } from '@angular/core';
import { enviroment } from '../../../enviroments/enviroment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResponse } from '../../interfaces/api-response';
import { Curso } from '../interfaces/curso';

@Injectable({
  providedIn: 'root'
})
export class CursoService {

  baseUrl: string = enviroment.apiUrl + 'curso/';

  constructor(private http: HttpClient) {}

  lista(): Observable<Curso[]> {
    return this.http.get<Curso[]>(`${this.baseUrl}`);
  }

}
