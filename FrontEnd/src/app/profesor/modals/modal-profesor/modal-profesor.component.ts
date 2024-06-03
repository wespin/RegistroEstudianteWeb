import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Profesor } from '../../interfaces/profesor';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProfesorService } from '../../services/profesor.service';
import { SharedService } from '../../../shared/shared.service';

@Component({
  selector: 'app-modal-profesor',
  templateUrl: './modal-profesor.component.html',
  styleUrl: './modal-profesor.component.css'
})
export class ModalProfesorComponent implements OnInit{
  formProfesor: FormGroup;
  titulo: string = "Agregar";
  nombreBoton: string = "Guardar";

  constructor(private modal: MatDialogRef<ModalProfesorComponent>,
    @Inject(MAT_DIALOG_DATA) public datosProfesor: Profesor,
    private fb: FormBuilder,
    private _profesorServicio: ProfesorService,
    private _sharedServicio: SharedService ){
      this.formProfesor = this.fb.group({
        apellido: ['', Validators.required],
        nombre: ['',Validators.required],
        fechaContratacion: ['', Validators.required]
    });

    if(this.datosProfesor != null) {
      this.titulo = 'Editar';
      this.nombreBoton = 'Actualizar';
    }
  }


  ngOnInit(): void {
   if(this.datosProfesor !=null)
      {
        this.formProfesor.patchValue({
          apellido: this.datosProfesor.apellido,
          nombre: this.datosProfesor.nombre,
          fechaContratacion: this.datosProfesor.fechaContratacion.toString()
        })
      }
  }

  crearModificarProfesor(){
    const profesor: Profesor = {
      profesorId: this.datosProfesor == null ? 0 : this.datosProfesor.profesorId,
      apellido: this.formProfesor.value.apellido,
      nombre: this.formProfesor.value.nombre,
      fechaContratacion: this.formProfesor.value.fechaContratacion
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
