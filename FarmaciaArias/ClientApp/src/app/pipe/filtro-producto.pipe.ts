import { Pipe, PipeTransform } from '@angular/core';
import { Producto } from '../farmacia/models/producto';

@Pipe({
  name: 'filtroProducto'
})
export class FiltroProductoPipe implements PipeTransform {

  transform(producto: Producto[], searchText: string): any {
    if (searchText == null) return producto;
    return producto.filter(p =>
    p.nombreP.toLowerCase()
    .indexOf(searchText.toLowerCase()) !== -1);
  }

}
