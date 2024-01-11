import { Routes } from '@angular/router'
import { LoginComponent } from './auth/components/login/login.component'
import { RegisterComponent } from './auth/components/register/register.component'
import { AuthGuard } from './auth/services/auth-guard.service'
import { CreateBookComponent } from './books/components/create-book/create-book.component'
import { DetailsBookComponent } from './books/components/details-book/details-book.component'
import { ListBooksComponent } from './books/components/list-books/list-books.component'

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'create', component: CreateBookComponent, canActivate: [AuthGuard] },
  { path: 'books', component: ListBooksComponent, canActivate: [AuthGuard] },
  { path: 'books/:id', component: DetailsBookComponent, canActivate: [AuthGuard] },
]
