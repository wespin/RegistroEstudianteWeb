import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from '../services/usuario.service';
import { SharedService } from '../../shared/shared.service';
import { Login } from '../interfaces/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  formLogin: FormGroup;
  ocultarPassword: boolean = true;
  mostrarLoading: boolean = false;

  constructor(private fb: FormBuilder,
             private router: Router,
             private usuarioServicio: UsuarioService,
             private sharedService: SharedService){
      this.formLogin = this.fb.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
      })        
  }

  iniciarSesion(){
    this.mostrarLoading = true;
    const request: Login = {
      username: this.formLogin.value.username,
      password: this.formLogin.value.password,
    };
    this.usuarioServicio.iniciarSesion(request).subscribe({
      next: (response) => {
        this.sharedService.guardarSesion(response);
        this.router.navigate(['layout']);
      },
      complete: () => {
        this.mostrarLoading = false;
      },
      error: (error) => {
        this.sharedService.mostrarAlerta(error.error(), "Error!");
        this.mostrarLoading = false;        
      }
    });
  }
}
