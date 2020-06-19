import { Component, OnInit } from '@angular/core';
import { Producto } from '../models/producto';
import { ProductoService } from 'src/app/services/producto.service';
import { FormBuilder, Validators, AbstractControl, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../../@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-producto-registro-reactivo',
  templateUrl: './producto-registro-reactivo.component.html',
  styleUrls: ['./producto-registro-reactivo.component.css']
})
export class ProductoRegistroReactivoComponent implements OnInit {

  producto: Producto;
  formGroup: FormGroup;
  submitted = false;

  constructor(private productoService: ProductoService, private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit() {
    this.buildForm();
  }

  private buildForm() {
    this.producto = new Producto();
    let myDate = new Date();
    this.producto.productoId = 0;
    this.producto.nombreP = '';
    this.producto.laboratorioP = '';
    this.producto.fechadevencimiento = myDate;
    this.producto.cantidadP = 0;
    
    this.formGroup = this.formBuilder.group({
      productoId: [this.producto.productoId, Validators.required],
      nombreP: [this.producto.nombreP, Validators.required],
      laboratorioP: [this.producto.laboratorioP, Validators.required],
      fechadevencimiento: [this.producto.fechadevencimiento, Validators.required],
      
      cantidadP: [this.producto.cantidadP, Validators.required ]

    });
  }

  get control() {
    return this.formGroup.controls;
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.producto = this.formGroup.value;
    this.productoService.post(this.producto).subscribe(p => {
      if (p != null) {

        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Producto creado';

        this.producto = p;
      }
    });

  }
}
