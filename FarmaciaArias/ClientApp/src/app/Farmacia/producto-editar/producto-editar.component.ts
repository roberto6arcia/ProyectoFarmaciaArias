import { Component, OnInit } from '@angular/core';
import { ProductoService } from './../../services/producto.service';
import { Producto } from './../models/producto';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-producto-editar',
  templateUrl: './producto-editar.component.html',
  styleUrls: ['./producto-editar.component.css']
})
export class ProductoEditarComponent implements OnInit {

  producto: Producto;
  constructor(private productoService: ProductoService, private rutaActiva: ActivatedRoute) { }

  ngOnInit() {
    this.producto = new Producto();
    const id = this.rutaActiva.snapshot.params.codigoP;
    this.productoService.getId(id).subscribe(p => {
      this.producto = p;
      this.producto != null ? alert('Se Consulta el producto') : alert('Error al Consultar');
    });
  }




}
