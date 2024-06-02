import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  titulo:string = 'FrontEnd';
  profesores: any;

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get('https://localhost:7088/api/Profesor').subscribe({
      next: response => this.profesores = response,
      error: error => console.log(error),
      complete: () => console.log('solicitud completa')
    })
  }

}
