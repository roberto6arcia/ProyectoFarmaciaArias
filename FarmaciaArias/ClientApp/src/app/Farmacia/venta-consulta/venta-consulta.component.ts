import { Component, OnInit } from '@angular/core';
import { Venta } from '../models/venta';
import { VentaService } from 'src/app/services/venta.service';
import { VentaViewModel } from '../models/venta-view-model';

@Component({
  selector: 'app-venta-consulta',
  templateUrl: './venta-consulta.component.html',
  styleUrls: ['./venta-consulta.component.css']
})
export class VentaConsultaComponent implements OnInit {

  /*ventas: Venta[];*/
  ventaViewModels: VentaViewModel[];
  constructor(private ventaService: VentaService) { }

  ngOnInit() {
    this.ventaService.get().subscribe(result => {
      /*this.ventas = result;*/
      this.ventaViewModels = result;
    });
  }

}
