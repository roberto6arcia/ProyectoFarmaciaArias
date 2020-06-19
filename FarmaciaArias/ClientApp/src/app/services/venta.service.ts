import { Injectable, Inject } from '@angular/core';
import { Venta } from '../farmacia/models/venta';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { VentaViewModel } from '../farmacia/models/venta-view-model';


@Injectable({
  providedIn: 'root'
})
export class VentaService {
  baseUrl: string;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {this.baseUrl = baseUrl; }

    /*get(): Observable<Venta[]> {
      return this.http.get<Venta[]>(this.baseUrl + 'api/Venta')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Venta[]>('Consulta Venta', null))
        );
    }*/

    get(): Observable<VentaViewModel[]> {
      return this.http.get<VentaViewModel[]>(this.baseUrl + 'api/Venta')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<VentaViewModel[]>('Consulta Venta', null))
        );
    }
  
    post(venta: Venta): Observable<Venta> {
      return this.http.post<Venta>(this.baseUrl + 'api/Venta', venta)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Venta>('Registrar Venta', null))
        );
    }
}
