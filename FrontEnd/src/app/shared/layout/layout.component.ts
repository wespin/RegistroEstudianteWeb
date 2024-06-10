import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { SharedService } from '../shared.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.css'
})
export class LayoutComponent implements OnInit{

  username: string = 'Admin';
 
  constructor(private router: Router, private sharedService: SharedService, private cookieService: CookieService)
  {
  }
 
   ngOnInit(): void {
     const usuarioSesion = this.sharedService.obtenerSesion();
     if(usuarioSesion!=null)
     {
       this.username = usuarioSesion;
     }
   }
 
    cerrarSesion() {
     this.sharedService.eliminarSesion();
 
     this.cookieService.delete('Authorization','/');

     this.router.navigate(['login']);
    }
 
 
 }