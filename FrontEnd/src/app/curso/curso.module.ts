import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { MaterialModule } from '../material/material.module';
import { CursoService } from './services/curso.service';



@NgModule({
  declarations: [],
  imports: [CommonModule, SharedModule, MaterialModule],
  providers:[CursoService]
})
export class CursoModule { }
