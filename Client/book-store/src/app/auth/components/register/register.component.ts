import { Component } from '@angular/core'
import { CommonModule } from '@angular/common'
import { IRegisterModel } from '../../models/register.model-interface'
import { AuthService } from '../../services/auth.service'
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from '@angular/router'

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  providers: [AuthService],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  formGroup: FormGroup

  constructor(
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder) {
      this.initForm()
    }

  register() {
    const username: string = this.formGroup.controls.username.value
    const email: string = this.formGroup.controls.email.value
    const password: string = this.formGroup.controls.password.value

    const model: IRegisterModel = {
      username: username,
      email: email,
      password: password,
    }

    this.authService.register(model).subscribe(data => {
      this.router.navigate(['login'])
    })
  }

  private initForm(): void {
    this.formGroup = this.fb.group({
      username: ["", [Validators.required]],
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required, Validators.minLength(6)]],
    })
  }

  get username() {
    return this.formGroup.get('username')
  }

  get email() {
    return this.formGroup.get('email')
  }

  get password() {
    return this.formGroup.get('password')
  }
}
