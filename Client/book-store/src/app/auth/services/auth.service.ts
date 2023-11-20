import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment.development';
import { ILoginModel } from '../models/login.model-interface';
import { IRegisterModel } from '../models/register.model-interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private baseUrl = environment.apiUrl
  constructor(private http: HttpClient) { }

  login(model: ILoginModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/identity/login`, model)
  }

  register(model: IRegisterModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/identity/register`, model)
  }

  getToken() {
    return localStorage.getItem('token')
  }
  
  saveToken(token: string) {
    localStorage.setItem('token', token)
  }
}
