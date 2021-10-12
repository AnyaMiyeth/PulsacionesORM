import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pago } from './pago';
import { of } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class PagoService {
  baseUrl: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  post(pago: Pago): Observable<Pago> {
    return this.http.post<Pago>(this.baseUrl + 'api/pago', pago).pipe(
      tap(_ => console.log("Guardó")),
      catchError(err => { console.log("Error al Guardar"); return of(pago) })
    );
  }
}
