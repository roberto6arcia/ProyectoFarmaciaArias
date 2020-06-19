import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, AbstractControl, FormGroup } from '@angular/forms';
import { NgbModal, ModalDismissReasons  } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../../@base/alert-modal/alert-modal.component';
import { ProductoService } from 'src/app/services/producto.service';
import { Producto } from '../models/producto';
import { Venta } from '../models/venta';
import { VentaService } from 'src/app/services/venta.service';
import { ProductoConsultaModalComponent  } from '../../@base/producto-consulta-modal/producto-consulta-modal.component';
import { DetalleVenta } from '../models/detalle-venta';
import { DetalleVentaViewModel } from '../models/detalle-venta-view-model';

@Component({
  selector: 'app-venta-registro-reactivo',
  templateUrl: './venta-registro-reactivo.component.html',
  styleUrls: ['./venta-registro-reactivo.component.css']
})
export class VentaRegistroReactivoComponent implements OnInit {
  
  venta: Venta;
  detallesVenta: DetalleVenta[];
  detalleVenta: DetalleVenta;
  detallesVentaViews: DetalleVentaViewModel[];
  formGroup: FormGroup;
  formGroupDetalle: FormGroup;
  ventaTotal:number;
  submitted = false;
  productos: Producto[];
  nombreProducto:string;
  
  constructor(private ventaService: VentaService, private productoService: ProductoService, private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit() {
    this.buildForm();
    this.productoService.get().subscribe(result => {
    this.productos = result;});
  }

  private buildForm() {
    this.venta = new Venta();
    this.detalleVenta= new DetalleVenta();
    let myDate = new Date();
    this.detallesVenta = [];
    this.detallesVentaViews = [];
    this.venta.fechadeventa = myDate;
    this.venta.estado ='';
    this.venta.total = 0;
    this.ventaTotal = 0;

    this.detalleVenta.codigoP = '';
    this.detalleVenta.cantidadV= 0;
    this.detalleVenta.precioV= 0;
    this.detalleVenta.totalVenta= 0;
    
    this.formGroup = this.formBuilder.group({
      fechadeventa: [this.venta.fechadeventa, Validators.required], 
      estado: [this.venta.estado, Validators.required],
    });

    this.formGroupDetalle  = this.formBuilder.group({
      codigoP: [this.detalleVenta.codigoP, Validators.required],
      cantidadV: [this.detalleVenta.cantidadV, Validators.required],    
      precioV: [this.detalleVenta.precioV, Validators.required],
      totalVenta: [''],

    });
  } 

  get control() {
    return this.formGroup.controls;
  }

  get controlDetalle() { 
    return this.formGroupDetalle.controls;
  }

  agregarDetalle(){
    let detalle = new DetalleVenta();
    detalle.cantidadV = this.formGroupDetalle.value.cantidadV;
    detalle.precioV= this.formGroupDetalle.value.precioV; 
    detalle.totalVenta= this.formGroupDetalle.value.totalVenta; 
    detalle.codigoP= this.formGroupDetalle.value.codigoP;
    this.detallesVenta.push(detalle);
    this.ventaTotal=this.ventaTotal+detalle.totalVenta;

    //Detalles con nombre del producto para mostrar en la tabla
    let detalleView = new DetalleVentaViewModel();
    detalleView.cantidadV = this.formGroupDetalle.value.cantidadV;
    detalleView.precioV= this.formGroupDetalle.value.precioV; 
    detalleView.totalVenta= this.formGroupDetalle.value.totalVenta; 
    detalleView.codigoP= this.formGroupDetalle.value.codigoP;
    detalleView.nombreProducto= this.nombreProducto;
    this.detallesVentaViews.push(detalleView);
    this.formGroupDetalle.reset();
    this.nombreProducto='';
  }

  /*buscarProducto() {
    this.productoService.getByIdentificacion(this.formGroupDetalle.value.productoId).subscribe(producto => {
        if (producto != null) {
            this.control['productoId'].setValue(producto.codigoP);
            this.control['productoNombre'].setValue(producto.nombreP);
        }
        else
        {
            this.openModalProducto();
        }
    });
}

//Manejo Modal
openModalProducto()
{
    this.modalService.open(ProductoConsultaModalComponent, { size: 'lg' }).result.then((producto) => this.actualizar(producto));
}

actualizar(producto: Producto) {
    
    this.formGroupDetalle.controls['productoId'].setValue(producto.codigoP);
    this.formGroupDetalle.controls['productoNombre'].setValue(producto.nombreP);
}
//Fin Manejo Modal*/

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.formGroup.invalid) {
      return;
    }
    this.add();

    this.submitted = false;
    this.formGroup.reset();
    this.ventaTotal=0;
    this.detallesVenta=[];
    this.formGroupDetalle.reset();
  }

  //calcula el total de la venta para ser mostrada en el formulario
  totalDetalleVenta(){
    var detalle =this.formGroupDetalle.controls.precioV.value*this.formGroupDetalle.controls.cantidadV.value;
    this.controlDetalle['totalVenta'].setValue(detalle);
   } 

   //pasa los valores del producto al detalle de venta  
   actualizaProducto(producto: Producto){
    
    this.controlDetalle['productoId'].setValue(producto.codigoP);
    this.nombreProducto=producto.nombreP;
   } 

  add() {
    this.venta = this.formGroup.value;
    this.venta.total= this.ventaTotal;
    this.venta.Detalles= this.detallesVenta;
    this.ventaService.post(this.venta).subscribe(p => {
      if (p != null) {

        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'Venta creada';

        this.venta = p;
      }
    });

  }

}
