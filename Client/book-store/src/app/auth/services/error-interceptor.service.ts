import { HttpInterceptorFn } from '@angular/common/http'
import { inject } from '@angular/core'
import { ToastrService } from 'ngx-toastr'
import { catchError, retry, throwError } from 'rxjs'

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const toastrService = inject(ToastrService)

  return next(req).pipe(
    retry(1),
    catchError((err) => {
      let message = ""
      if (err.status === 400) {
        message = "400"
      } else if (err.status === 401) {
        message = "The token is expired or you should be logged in"
      } else if (err.status === 404) {
        message = "404"
      } else {
        message = "Unexpected error occured!"
      }

      toastrService.error(message, err.status)

      return throwError(() => new Error(err))
    })
  )
}
