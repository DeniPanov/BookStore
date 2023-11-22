import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { environment } from '../../../environments/environment.development'
import { ICreateBookModel } from '../models/create-book.model-interface'
import { IUpdateBookModel } from '../models/update-book.model-interface'

@Injectable({
  providedIn: 'root',
})
export class BookService {
  private baseUrl = environment.apiUrl
  constructor(private http: HttpClient) { }

  create(model: ICreateBookModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/books`, model)
  }

  getBooks(): Observable<any> {
    return this.http.get(`${this.baseUrl}/books`)
  }

  getDetails(bookId: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/books/${bookId}`)
  }

  update(model: IUpdateBookModel): Observable<any> {
    return this.http.put(`${this.baseUrl}/books`, model)
  }

  delete(bookId: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/books/${bookId}`)
  }
}
