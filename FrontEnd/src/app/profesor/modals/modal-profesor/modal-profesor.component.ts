import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Profesor } from '../../interfaces/profesor';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProfesorService } from '../../services/profesor.service';
import { SharedService } from '../../../shared/shared.service';
import { Curso } from '../../../curso/interfaces/curso';
import { CursoService } from '../../../curso/services/curso.service';

@Component({
  selector: 'app-modal-profesor',
  templateUrl: './modal-profesor.component.html',
  styleUrl: './modal-profesor.component.css'
})
export class ModalProfesorComponent implements OnInit{
  formProfesor: FormGroup;
  titulo: string = "Agregar";
  nombreBoton: string = "Guardar";
  cursos: Curso[];

  constructor(private modal: MatDialogRef<ModalProfesorComponent>,
    @Inject(MAT_DIALOG_DATA) 
    public datosProfesor: Profesor,
    private fb: FormBuilder,
    private _profesorServicio: ProfesorService,
    private _sharedServicio: SharedService,
    private _cursoServicio: CursoService){
      this.formProfesor = this.fb.group({
        apellido: ['', Validators.required],
        nombre: ['',Validators.required],
        fechaContratacion: ['', Validators.required],
        cursos: ['', Validators.required]
    });

    if(this.datosProfesor != null) {
      this.titulo = 'Editar';
      this.nombreBoton = 'Actualizar';
    }
    this.getCursos();
  }

  getCursos() {
     this._cursoServicio.lista().subscribe({
      next: response => this.cursos = response,
      error: error => console.log(error),
      complete: () => console.log('solicitud Curso completa desde modal de profesores')
    })
  }

  ngOnInit(): void {


    if(this.datosProfesor !=null)
      {
        this.formProfesor.patchValue({
          apellido: this.datosProfesor.apellido,
          nombre: this.datosProfesor.nombre,
          fechaContratacion: this.datosProfesor.fechaContratacion.toString(),
          cursos: []
        })
      }
      else{
        this.formProfesor.patchValue({       
          cursos:  this._cursoServicio.lista()
        })
      }
  }

  crearModificarProfesor(){
    const profesor: Profesor = {
      profesorId: this.datosProfesor == null ? 0 : this.datosProfesor.profesorId,
      apellido: this.formProfesor.value.apellido,
      nombre: this.formProfesor.value.nombre,
      fechaContratacion: this.formProfesor.value.fechaContratacion,
      cursos: this.formProfesor.value.cursos
    }

    const selectedCursos = this.cursos.filter(curso => curso.seleccionado);
    console.log('Number of selected cursos:', selectedCursos.length);
  
    if (selectedCursos.length > 2) {
      console.log('You can only select up to 2 cursos.');
      this._sharedServicio.mostrarAlerta("Un Profesor solo puede tener hasta 2 materias", 'Informativo!');
      return;
    }    

    if(this.datosProfesor == null)
    {
       // Crear nueva Profesor
       this._profesorServicio.crear(profesor).subscribe({
         next: (data) => {
           if(data)
           {
            this._sharedServicio.mostrarAlerta('El Profesor ha sido grabado con Exito!', 'Completo');
            this.modal.close("true");
           }
           else
             this._sharedServicio.mostrarAlerta('No se pudo crear la profesor', 'Error!');
         },
         error: (e) => {
          this._sharedServicio.mostrarAlerta(e.error.mensaje, 'Error!');
         }
       })
    }
    else
    {
        // Editar/Actualizar Profesor
         this._profesorServicio.editar(profesor).subscribe({
         next: (data) => {
           if(data)
           {
            this._sharedServicio.mostrarAlerta('El Profesor ha sido actualizado con Exito!', 'Completo');
            this.modal.close("true");
           }
           else
             this._sharedServicio.mostrarAlerta('No se pudo actualizar el profesor', 'Error!');
         },
         error: (e) => {
          this._sharedServicio.mostrarAlerta(e.error.mensaje, 'Error!');
         }
       })
    }
  }
}
