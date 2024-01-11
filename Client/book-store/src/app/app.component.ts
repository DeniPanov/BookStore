import { Component } from '@angular/core'
import { CommonModule } from '@angular/common'
import { RouterOutlet } from '@angular/router'
import { LoginComponent } from './auth/components/login/login.component'
import { RegisterComponent } from './auth/components/register/register.component'
import { AuthService } from './auth/services/auth.service'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet,
    LoginComponent, RegisterComponent],
  providers: [AuthService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'book-store';
}
