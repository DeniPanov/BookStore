import { Validators } from "@angular/forms"
import { BaseFormModel } from "../../../core/models/base-form.model"
import { IRegisterModel } from "../register.model-interface"

export class RegisterFormModel extends BaseFormModel<IRegisterModel> {
  constructor() {
    super()
    this.formGroup = this.formBuilder.group({
      username: ['', Validators.required, Validators.minLength(3)],
      email: ['', Validators.required, Validators.email],
      password: ['', Validators.required, Validators.minLength(6)],
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
