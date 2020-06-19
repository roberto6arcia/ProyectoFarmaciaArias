import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuarioRegistroReactivoComponent } from './usuario-registro-reactivo.component';

describe('UsuarioRegistroReactivoComponent', () => {
  let component: UsuarioRegistroReactivoComponent;
  let fixture: ComponentFixture<UsuarioRegistroReactivoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsuarioRegistroReactivoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuarioRegistroReactivoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
