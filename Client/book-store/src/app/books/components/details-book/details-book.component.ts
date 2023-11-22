import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { BookService } from '../../services/book.service';
import { IDetailsBookModel } from '../../models/details-book.model-interface';

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

  constructor(private route: ActivatedRoute, bookService: BookService) {
    route.params.subscribe(res => {
      this.bookId = res['id']

      bookService.getDetails(+this.bookId).subscribe(book => {
        this.book = book
      })
    })
  }

  ngOnInit(): void {
    // throw new Error('Method not implemented.');  
  }

}
