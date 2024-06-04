import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ListadoProfesorComponent } from '../profesor/pages/listado-profesor/listado-profesor.component';
import { } from '../profesor/profesor.module';
import { ListadoEstudianteComponent } from '../estudiante/pages/listado-estudiante/listado-estudiante.component';


const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: 'dashboard', component: DashboardComponent, pathMatch: 'full',  },
      { path: 'profesores', component: ListadoProfesorComponent, pathMatch: 'full',  },
      { path: 'estudiantes', component: ListadoEstudianteComponent, pathMatch: 'full',  },
      { path: '**', redirectTo: '', pathMatch: 'full' },
    ],
  },
];


@NgModule({
  declarations: [],
  imports: [CommonModule,RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }
