import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalProfesorComponent } from './modal-profesor.component';

describe('ModalProfesorComponent', () => {
  let component: ModalProfesorComponent;
  let fixture: ComponentFixture<ModalProfesorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ModalProfesorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ModalProfesorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
