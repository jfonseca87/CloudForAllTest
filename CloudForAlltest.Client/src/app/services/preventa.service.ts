import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Preventa } from 'src/app/models/preventa';
import { Response } from 'src/app/models/response';

@Injectable({
  providedIn: 'root'
})
export class PreventaService {

  constructor(private client: HttpClient) { }

  getPreventas(): Observable<Response> {
    return this.client.get<Response>(`${environment.baseUrl}preventa`);
  }

  getPreventa(id: string): Observable<Response> {
    return this.client.get<Response>(`${environment.baseUrl}preventa/${id}`);
  }

  createPreventa(preventa: Preventa): Observable<Response> {
    return this.client.post<Response>(`${environment.baseUrl}preventa`, preventa);
  }

  updatePreventa(preventa: Preventa): Observable<Response> {
    return this.client.put<Response>(`${environment.baseUrl}preventa`, preventa);
  }

  deletePreventa(id: string): Observable<Response> {
    return this.client.delete<Response>(`${environment.baseUrl}preventa/${id}`);
  }
}
