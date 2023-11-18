import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginFormModel } from '../../models/forms/logn.form-model';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
   loginForm: LoginFormModel = new LoginFormModel()

  constructor() {
  }

  login() {
    
  }
}
