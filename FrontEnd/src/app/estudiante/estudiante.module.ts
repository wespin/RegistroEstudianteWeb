import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EstudianteService } from './services/estudiante.service';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../material/material.module';
import { ModalEstudianteComponent } from './modals/modal-estudiante/modal-estudiante.component';
import { ListadoEstudianteComponent } from './pages/listado-estudiante/listado-estudiante.component';

@NgModule({
  declarations: [ListadoEstudianteComponent, ModalEstudianteComponent],
  imports: [CommonModule, SharedModule, MaterialModule],
  providers:[EstudianteService]
})
export class EstudianteModule { }
