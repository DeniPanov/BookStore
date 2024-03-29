import { Component } from '@angular/core'
import { CommonModule } from '@angular/common'
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms'
import { ILoginModel } from '../../models/login.model-interface'
import { AuthService } from '../../services/auth.service'
import { Router } from '@angular/router'
import { ToastrService } from 'ngx-toastr'

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
   formGroup: FormGroup

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private toastrService: ToastrService,
    private router: Router) {
    this.initForm()
  }

  public login(): void {
    const username: string = this.formGroup.controls.username.value
    const password: string = this.formGroup.controls.password.value

    const model: ILoginModel = {
      username: username,
      password: password
    }

    this.authService.login(model).subscribe(data => {
      this.authService.saveToken(data['token'])
      this.toastrService.success("You've logged in successfuly!")

      this.router.navigate(['books'])
    })
  }

  private initForm(): void {
    this.formGroup = this.fb.group({
      username: ["", [Validators.required]],
      password: ["", [Validators.required, Validators.minLength(6)]],
    })
  }

  get username() {
    return this.formGroup.get('username')
  }

  get password() {
    return this.formGroup.get('password')
  }
}
