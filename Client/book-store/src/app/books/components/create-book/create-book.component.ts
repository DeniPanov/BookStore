import { Component } from '@angular/core'
import { CommonModule } from '@angular/common'
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms'
import { ICreateBookModel } from '../../models/create-book.model-interface'
import { BookService } from '../../services/book.service'
import { AuthGuard, AuthGuardService } from '../../../auth/services/auth-guard.service'

@Component({
  selector: 'app-create-book',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  providers: [],
  templateUrl: './create-book.component.html',
  styleUrl: './create-book.component.css'
})
export class CreateBookComponent {
  formGroup: FormGroup
  bookId: number

  constructor(
    private bookService: BookService,
    private fb: FormBuilder) {
      this.initForm()
    }

  create() {
    const model: ICreateBookModel = this.mapModel()

    this.bookService.create(model).subscribe(data => {
      this.bookId = data
    })
  }

  private initForm(): void {
    this.formGroup = this.fb.group({
      title: ['', [Validators.required, Validators.maxLength(150)]],
      summary: ['', [Validators.required, Validators.maxLength(1000)]],
      description: ['', [Validators.maxLength(2000)]],
      author: ['', [Validators.required, Validators.maxLength(100)]],
      isbn: ['', [Validators.maxLength(13)]],
      bookImage: [''],
      price: [0, [Validators.required]],
      quantity: [0, [Validators.required]],
      year: [0, [Validators.min(0), Validators.max(2023)]],
      pageCount: [0],
      purchasesCount: [0]
    })
  }

  private mapModel(): ICreateBookModel {
    const controls = this.formGroup.controls

    const model: ICreateBookModel = {
      title: controls.title.value,
      summary: controls.summary.value,
      description: controls.description.value,
      author: controls.author.value,
      isbn: controls.isbn.value,
      bookImage: controls.bookImage.value,
      price: controls.price.value,
      quantity: controls.quantity.value,
      year: controls.year.value,
      pageCount: controls.pageCount.value,
      purchasesCount: controls.purchasesCount.value
    }

    return model
  }

  get title() {
    return this.formGroup.get('title')
  }

  get summary() {
    return this.formGroup.get('summary')
  }

  get description() {
    return this.formGroup.get('description')
  }

  get author() {
    return this.formGroup.get('author')
  }

  get isbn() {
    return this.formGroup.get('isbn')
  }

  get price() {
    return this.formGroup.get('price')
  }

  get quantity() {
    return this.formGroup.get('quantity')
  }

  get year() {
    return this.formGroup.get('sumyearmary')
  }
}
