import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Estudiante } from '../../interfaces/estudiante';
import { EstudianteService } from '../../services/estudiante.service';
import { SharedService } from '../../../shared/shared.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalEstudianteComponent } from '../../modals/modal-estudiante/modal-estudiante.component';
import Swal from 'sweetalert2';
import { MatCardModule } from '@angular/material/card';
import { ModalEstudianteRegistroComponent } from '../../modals/modal-estudiante-registro/modal-estudiante-registro.component';
import { Curso } from '../../../curso/interfaces/curso';
import { CursoService } from '../../../curso/services/curso.service';

@Component({
  selector: 'app-listado-estudiante',
  templateUrl: './listado-estudiante.component.html',
  styleUrl: './listado-estudiante.component.css'
})
export class ListadoEstudianteComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'apellido',
    'nombre',
    'materias_inscritas',
    'acciones',
  ];

  listaCursos: Curso[];

  dataSource = new MatTableDataSource<Estudiante>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _estudianteServicio: EstudianteService,
    private _sharedService: SharedService,
    private dialog: MatDialog,
    private _cursoService: CursoService
  ) { this.getListaCursos();}

  ngOnInit(): void {
    this.obtenerEstudiantes();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  getListaCursos() {
    this._cursoService.lista().subscribe({
     next: response => this.listaCursos = response,
     error: error => console.log(error),
     complete: () => console.log('solicitud Curso completa desde modal de profesores')
   })
 }

  getCurso(_cursoId: number) {
    const cursos = this.listaCursos.filter(e => e.cursoId === _cursoId);
    return cursos ? cursos : [];
  }

  obtenerEstudiantes() {
    this._estudianteServicio.lista().subscribe({
      next: (data) => {
        if (data) {
          this.dataSource = new MatTableDataSource(data);
          this.dataSource.paginator = this.paginator;
        } else
          this._sharedService.mostrarAlerta(
            'No se encontraron datos',
            'Advertencia!'
          );
      },
      error: (e) => {
        this._sharedService.mostrarAlerta(e.error.mensaje, 'Error!');
      },
    });
  }

  nuevoEstudiante() {
    this.dialog
      .open(ModalEstudianteComponent, { disableClose: true, width: '400px' })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerEstudiantes();
    });
  }

  editarEstudiante(estudiante: Estudiante) {
    this.dialog
      .open(ModalEstudianteComponent, {
        disableClose: true,
        width: '400px',
        data: estudiante,
      })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerEstudiantes();
      });
  }

  removerEstudiante(estudiante: Estudiante) {
    Swal.fire({
      title: 'Desea Eliminar el Estudiante?',
      text: estudiante.nombre,
      icon: 'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'Sí, eliminar',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No',
    }).then((resultado) => {
      if (resultado.isConfirmed) {
        this._estudianteServicio.eliminar(estudiante.estudianteId).subscribe({
          next: (data) => {
            if (data.isExitoso) {
              this._sharedService.mostrarAlerta(
                'El estudiante fue eliminado',
                'Completo'
              );
              this.obtenerEstudiantes();
            } else {
              this._sharedService.mostrarAlerta(
                'No se pudo eliminar el estudiante',
                'Error!'
              );
            }
          },
          error: (e) => {
             this._sharedService.mostrarAlerta(e.error.mensaje, 'Error!');
          },
        });
      }
    });
  }

  registrarEstudiante(estudiante: Estudiante){
    this.dialog
      .open(ModalEstudianteRegistroComponent, { 
        disableClose: true, 
        width: '600px',
        data: estudiante 
      })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerEstudiantes();
    });
  }


  aplicarFiltroListado(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
}