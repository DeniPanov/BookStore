import { Validators } from "@angular/forms"
import { BaseFormModel } from "../../../core/models/base-form.model"
import { ILoginModel } from "../login.model-interface"

export class LoginFormModel extends BaseFormModel<ILoginModel> {
  constructor() {
    super()
    this.formGroup = this.formBuilder.group({
      username: ['', [Validators.required, Validators.minLength(3)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    })
  }
}
