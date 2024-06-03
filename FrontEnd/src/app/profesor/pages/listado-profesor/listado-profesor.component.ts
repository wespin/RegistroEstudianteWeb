import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Profesor } from '../../interfaces/profesor';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { ProfesorService } from '../../services/profesor.service';
import { SharedService } from '../../../shared/shared.service';
import { MatDialog } from '@angular/material/dialog';


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
    /*this.dialog
      .open(ModalEspecialidadComponent, { disableClose: true, width: '400px' })
      .afterClosed()
      .subscribe((resultado) => {
        if (resultado === 'true') this.obtenerEspecialidades();
      });*/
  }

  editarProfesor(profesor: Profesor) {
  }
  removerProfesor(profesor: Profesor) {
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