import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductoRegistroReactivoComponent } from './producto-registro-reactivo.component';

describe('ProductoRegistroReactivoComponent', () => {
  let component: ProductoRegistroReactivoComponent;
  let fixture: ComponentFixture<ProductoRegistroReactivoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductoRegistroReactivoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductoRegistroReactivoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
