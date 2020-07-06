import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private client: HttpClient) { }

  login(user: User): Observable<Response> {
    return this.client.post<Response>(`${environment.baseUrl}usuario`, user);
  }
}
