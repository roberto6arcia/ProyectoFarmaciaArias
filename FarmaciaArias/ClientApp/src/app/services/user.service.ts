import { Injectable, Inject } from '@angular/core';
import { User } from '../seguridad/user';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl: string;

  constructor(private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) { this.baseUrl = baseUrl; }

    get(): Observable<User[]> {
      return this.http.get<User[]>(this.baseUrl + 'api/User')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<User[]>('Consulta User', null))
        );
    }

    post(user: User): Observable<User> {
      return this.http.post<User>(this.baseUrl + 'api/User', user)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<User>('Registrar User', null))
        );
    }
}
