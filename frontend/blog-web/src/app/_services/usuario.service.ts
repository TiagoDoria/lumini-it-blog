
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario }  from '../_models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  baseURL = 'http://localhost:5001/api/usuario';

  constructor(private http: HttpClient) { }

  postUsuario(usuario: Usuario) {
    return this.http.post(this.baseURL, usuario);
  }

}
