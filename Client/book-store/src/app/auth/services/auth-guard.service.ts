import { inject, Injectable } from '@angular/core'
import { CanActivateFn, Router } from '@angular/router'
import { AuthService } from './auth.service'

@Injectable({
  providedIn: 'root',
})
export class AuthGuardService {
  constructor(
    private authService: AuthService,
    private router: Router) {}

  canActivate(): boolean {
    if (this.authService.isAuthenticated()) {
      return true
    } else {
      this.router.navigate(['login'])
      return false
    }
  }
}

export const AuthGuard: CanActivateFn = (): boolean => {
  return inject(AuthGuardService).canActivate()
}
