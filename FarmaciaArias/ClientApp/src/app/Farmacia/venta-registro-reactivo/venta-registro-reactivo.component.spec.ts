import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VentaRegistroReactivoComponent } from './venta-registro-reactivo.component';

describe('VentaRegistroReactivoComponent', () => {
  let component: VentaRegistroReactivoComponent;
  let fixture: ComponentFixture<VentaRegistroReactivoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VentaRegistroReactivoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VentaRegistroReactivoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
