import { HttpInterceptorFn } from '@angular/common/http'
import { inject } from '@angular/core'
import { AuthService } from './auth.service'

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  const authService = inject(AuthService)
  const authToken = authService.getToken()

  const authReq = req.clone({ setHeaders: {
    Authorization: `Bearer ${authToken}`
  }})

  return next(authReq)
}
