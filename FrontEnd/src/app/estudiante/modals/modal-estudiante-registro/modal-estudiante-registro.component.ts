import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { EstudianteService } from '../../services/estudiante.service';
import { SharedService } from '../../../shared/shared.service';
import { Estudiante } from '../../interfaces/estudiante';

@Component({
  selector: 'app-modal-estudiante-registro',
  templateUrl: './modal-estudiante-registro.component.html',
  styleUrl: './modal-estudiante-registro.component.css'
})
export class ModalEstudianteRegistroComponent  implements OnInit{
  formEstudiante: FormGroup;
  titulo: string = "Agregar";
  nombreBoton: string = "Guardar";

  constructor(private modal: MatDialogRef<ModalEstudianteRegistroComponent>,
    @Inject(MAT_DIALOG_DATA) 
    public datosEstudiante: Estudiante,
    private fb: FormBuilder,
    private _estudianteServicio: EstudianteService,
    private _sharedService: SharedService)
  {
        this.formEstudiante = this.fb.group({
          apellido: ['', Validators.required],
          nombre: ['',Validators.required]
      });
  }

  ngOnInit(): void {
    if(this.datosEstudiante !=null)
      {
        this.formEstudiante.patchValue({
          apellido: this.datosEstudiante.apellido,
          nombre: this.datosEstudiante.nombre
        })
      }
  }

  registrarEstudianteCurso(){
    const estudiante: Estudiante = {
      estudianteId: this.datosEstudiante == null ? 0 : this.datosEstudiante.estudianteId,
      apellido: this.formEstudiante.value.apellido,
      nombre: this.formEstudiante.value.nombre,

    }

    if(this.datosEstudiante != null)
    {
       // Crear nueva Profesor
       this._estudianteServicio.crear(estudiante).subscribe({
         next: (data) => {
           if(data)
           {
            this._sharedService.mostrarAlerta('El Registro de Curso del Estudiante ha sido grabado con Exito!', 'Completo');
            this.modal.close("true");
           }
           else
             this._sharedService.mostrarAlerta('No se pudo crear la registro', 'Error!');
         },
         error: (e) => {
          this._sharedService.mostrarAlerta(e.error.mensaje, 'Error!');
         }
       })
    }
  }
}
