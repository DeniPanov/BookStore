import { HttpInterceptorFn } from '@angular/common/http'
import { catchError, retry, throwError } from 'rxjs'

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  return next(req).pipe(
    retry(1),
    catchError((err) => {
      if (err.status === 400) {
        alert("400")
      } else if (err.status === 401) {
        alert("401")
      } else if (err.status === 404) {
        alert("404")
      } else {
        // global error message
        alert("global error message")
      }

      return throwError(() => new Error(err))
    })
  )
}
