import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoConsultaModalComponent } from './producto-consulta-modal.component';

describe('ProductoConsultaModalComponent', () => {
  let component: ProductoConsultaModalComponent;
  let fixture: ComponentFixture<ProductoConsultaModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductoConsultaModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoConsultaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
