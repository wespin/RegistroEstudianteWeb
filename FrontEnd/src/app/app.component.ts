import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { CursoService } from './curso/services/curso.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  titulo:string = 'FrontEnd';
  profesores: any;
  cursos: any;
  constructor(private http: HttpClient, private _cursoService: CursoService){}

  ngOnInit(): void {
   /* this.http.get('https://localhost:7088/api/Profesor').subscribe({
      next: response => this.profesores = response,
      error: error => console.log(error),
      complete: () => console.log('solicitud completa')
    })
*/
 /*   this._cursoService.lista().subscribe({
      next: response => this.cursos = response,
      error: error => console.log(error),
      complete: () => console.log('solicitud Curso completa')
    })
*/
  }
}
