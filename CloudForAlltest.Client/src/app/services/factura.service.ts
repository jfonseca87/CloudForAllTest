import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Factura } from 'src/app/models/factura';
import { Response } from 'src/app/models/response';

@Injectable({
  providedIn: 'root'
})
export class FacturaService {

  constructor(private client: HttpClient) { }

  getFacturas(): Observable<Response> {
    return this.client.get<Response>(`${environment.baseUrl}factura`);
  }

  createFactura(factura: Factura): Observable<Response> {
    return this.client.post<Response>(`${environment.baseUrl}factura`, factura);
  }
}
