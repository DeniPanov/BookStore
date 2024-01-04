import { Component, OnInit } from '@angular/core'
import { CommonModule } from '@angular/common'
import { BookService } from '../../services/book.service'
import { IListBooksModel } from '../../models/list-books.model-interface'
import { Router, RouterModule } from '@angular/router'
import { IDetailsBookModel } from '../../models/details-book.model-interface'

@Component({
  selector: 'app-list-books',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
  ],
  providers: [],
  templateUrl: './list-books.component.html',
  // styleUrl: './list-books.component.css'
})
export class ListBooksComponent implements OnInit {
  books: IListBooksModel[]
  currentBook: IDetailsBookModel

  constructor(private bookService: BookService, private router: Router) { }

  ngOnInit(): void {
    this.getBooks()
  }

  getBooks() {
    this.bookService.getBooks().subscribe(books => {
      this.books = books
    })
  }

  update(bookId: number) {
    this.bookService.getDetails(bookId).subscribe(book => {
      if (book) {
        this.currentBook = book
      }
    })
  }

  delete(bookId: number) {
    this.bookService.delete(bookId).subscribe(() => {
      this.getBooks()
    })
  }

  // navigateToDetails(bookId: number) {
  //   this.router.navigate(['books', bookId ])
  // }
}
