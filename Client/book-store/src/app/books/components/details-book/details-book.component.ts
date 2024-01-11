import { Component, OnInit } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ActivatedRoute } from '@angular/router'
import { BookService } from '../../services/book.service'
import { IDetailsBookModel } from '../../models/details-book.model-interface'
import { map, mergeMap } from 'rxjs'

@Component({
  selector: 'app-details-book',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './details-book.component.html',
  styleUrl: './details-book.component.css'
})
export class DetailsBookComponent implements OnInit {
  bookId: string
  book: IDetailsBookModel

  constructor(private route: ActivatedRoute, private bookService: BookService) {
    this.fetchData()
  }

  ngOnInit(): void {
    // throw new Error('Method not implemented.');
  }

  fetchData() {
    this.route.params.pipe(map(params => {
      const bookId = params['id']
      return bookId
    }), mergeMap(bookId => this.bookService.getDetails(bookId))).subscribe(book => {
      this.book = book
    })
  }
}
