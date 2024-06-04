import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalEstudianteRegistroComponent } from './modal-estudiante-registro.component';

describe('ModalEstudianteRegistroComponent', () => {
  let component: ModalEstudianteRegistroComponent;
  let fixture: ComponentFixture<ModalEstudianteRegistroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ModalEstudianteRegistroComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModalEstudianteRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
