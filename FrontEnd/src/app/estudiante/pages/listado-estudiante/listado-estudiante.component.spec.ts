import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListadoEstudianteComponent } from './listado-estudiante.component';

describe('ListadoEstudianteComponent', () => {
  let component: ListadoEstudianteComponent;
  let fixture: ComponentFixture<ListadoEstudianteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListadoEstudianteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListadoEstudianteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
