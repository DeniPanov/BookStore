import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { environment } from '../../../environments/environment.development'
import { ICreateBookModel } from '../models/create-book.model-interface'

@Injectable({
  providedIn: 'root',
})
export class BookService {
  private baseUrl = environment.apiUrl
  constructor(private http: HttpClient) { }

  create(model: ICreateBookModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/books`, model)
  }
}
