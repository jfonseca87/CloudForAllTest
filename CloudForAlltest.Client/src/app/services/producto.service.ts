import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Producto } from 'src/app/models/producto';
import { Response } from 'src/app/models/response';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  constructor(private client: HttpClient) { }

  getProductos(): Observable<Response> {
    return this.client.get<Response>(`${environment.baseUrl}producto`);
  }

  getProducto(id: string): Observable<Response> {
    return this.client.get<Response>(`${environment.baseUrl}producto/${id}`);
  }

  createProducto(producto: Producto): Observable<Response> {
    return this.client.post<Response>(`${environment.baseUrl}producto`, producto);
  }

  updateProducto(producto: Producto): Observable<Response> {
    return this.client.put<Response>(`${environment.baseUrl}producto`, producto);
  }

  deleteProducto(id: string): Observable<Response> {
    return this.client.delete<Response>(`${environment.baseUrl}producto/${id}`);
  }
}
