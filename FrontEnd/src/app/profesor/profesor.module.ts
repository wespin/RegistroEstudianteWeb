import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../material/material.module';
import { ProfesorService } from './services/profesor.service';
import { ListadoProfesorComponent } from './pages/listado-profesor/listado-profesor.component';
import { ModalProfesorComponent } from './modals/modal-profesor/modal-profesor.component';



@NgModule({
  declarations: [ListadoProfesorComponent, ModalProfesorComponent],
  imports: [CommonModule, SharedModule, MaterialModule],
  providers:[ProfesorService]
})
export class ProfesorModule { }
