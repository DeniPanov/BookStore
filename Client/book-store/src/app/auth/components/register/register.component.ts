import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterFormModel } from '../../models/forms/register.form-model';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: RegisterFormModel = new RegisterFormModel()

  constructor() {}

  register() {
    
  }
}
