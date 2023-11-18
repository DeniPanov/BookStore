import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterFormModel } from '../../models/forms/register.form-model';
import { IRegisterModel } from '../../models/register.model-interface';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: RegisterFormModel = new RegisterFormModel()

  constructor(private authService: AuthService) {}

  register() {
    const username: string = this.registerForm.formGroup.controls.username.value
    const email: string = this.registerForm.formGroup.controls.email.value
    const password: string = this.registerForm.formGroup.controls.password.value

    const model:IRegisterModel = {
      username: username,
      email: email,
      password: password,
    }

    this.authService.register(model).subscribe(data => {
      console.log(data)
    })
  }

  get username() {
    return this.registerForm.formGroup.get('username')
  }

  get email() {
    return this.registerForm.formGroup.get('email')
  }

  get password() {
    return this.registerForm.formGroup.get('password')
  }
}
