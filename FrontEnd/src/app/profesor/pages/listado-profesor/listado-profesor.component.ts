import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Profesor } from '../../interfaces/profesor';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ProfesorService } from '../../services/profesor.service';
import { SharedService } from '../../../shared/shared.service';
import { MatDialog } from '@angular/material/dialog';
import { ModalProfesorComponent } from '../../modals/modal-profesor/modal-profesor.component';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-listado-profesor',
  templateUrl: './listado-profesor.component.html',
  styleUrl: './listado-profesor.component.css'
})
export class ListadoProfesorComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'apellido',
    'nombre',
    'fechaContratacion',
    'acciones',
  ];
  //dataInicial: Profesor[] = [];
  dataSource = new MatTableDataSource<Profesor>();//new MatTableDataSource(this.dataInicial);
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private _profesorServicio: ProfesorService,
    private _sharedService: SharedService,
    private dialog: MatDialog
  ) {}

  nuevoProfesor() {
    this.dialog
      .open(ModalProfesorComponent, { disableClose: true, width: '400px' })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerProfesores();
      });
  }

  editarProfesor(profesor: Profesor) {
    this.dialog
      .open(ModalProfesorComponent, {
        disableClose: true,
        width: '400px',
        data: profesor,
      })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerProfesores();
      });

  }
  removerProfesor(profesor: Profesor) {
    Swal.fire({
      title: 'Desea Eliminar el Profesor?',
      text: profesor.nombre,
      icon: 'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'Sí, eliminar',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'No',
    }).then((resultado) => {
      if (resultado.isConfirmed) {
        this._profesorServicio.eliminar(profesor.profesorId).subscribe({
          next: (data) => {
            if (data.isExitoso) {
              this._sharedService.mostrarAlerta(
                'El profesor fue eliminado',
                'Completo'
              );
              this.obtenerProfesores();
            } else {
              this._sharedService.mostrarAlerta(
                'No se pudo eliminar el profesor',
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
  
  
  obtenerProfesores() {
    this._profesorServicio.lista().subscribe({
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

  aplicarFiltroListado(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }
  
  ngOnInit(): void {
    this.obtenerProfesores();
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

}