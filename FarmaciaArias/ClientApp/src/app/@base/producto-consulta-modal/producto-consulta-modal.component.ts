import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Producto } from '../../farmacia/models/producto';

@Component({
  selector: 'app-producto-consulta-modal',
  templateUrl: './producto-consulta-modal.component.html',
  styleUrls: ['./producto-consulta-modal.component.css']
})
export class ProductoConsultaModalComponent {

  constructor(public activeModal: NgbActiveModal) { }

  actualizar(producto: Producto) {
    this.activeModal.close(producto);

  }

}
