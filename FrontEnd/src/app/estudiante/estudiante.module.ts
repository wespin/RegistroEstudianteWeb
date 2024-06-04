import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../material/material.module';
import { EstudianteService } from './services/estudiante.service';
import { ListadoEstudianteComponent } from './pages/listado-estudiante/listado-estudiante.component';
import { ModalEstudianteComponent } from './modals/modal-estudiante/modal-estudiante.component';
import { ModalEstudianteRegistroComponent } from './modals/modal-estudiante-registro/modal-estudiante-registro.component';


@NgModule({
  declarations: [ListadoEstudianteComponent, ModalEstudianteComponent, ModalEstudianteRegistroComponent],
  imports: [CommonModule, SharedModule, MaterialModule],
  providers:[EstudianteService]
})

export class EstudianteModule { }
