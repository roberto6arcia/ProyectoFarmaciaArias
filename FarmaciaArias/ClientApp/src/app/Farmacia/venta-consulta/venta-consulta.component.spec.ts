import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VentaConsultaComponent } from './venta-consulta.component';

describe('VentaConsultaComponent', () => {
  let component: VentaConsultaComponent;
  let fixture: ComponentFixture<VentaConsultaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VentaConsultaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VentaConsultaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
