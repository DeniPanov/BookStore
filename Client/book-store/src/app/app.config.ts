import { ApplicationConfig, importProvidersFrom } from '@angular/core'
import { provideRouter } from '@angular/router'
import { routes } from './app.routes'
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http'
import { tokenInterceptor } from './auth/services/token-interceptor.service'
import { errorInterceptor } from './auth/services/error-interceptor.service'
import { provideAnimations } from '@angular/platform-browser/animations'
import { provideToastr } from 'ngx-toastr'
import { ReactiveFormsModule } from '@angular/forms'

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    importProvidersFrom(ReactiveFormsModule),
    provideAnimations(),
    provideToastr({
      timeOut: 30000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    provideHttpClient(
      withFetch(),
      withInterceptors([ tokenInterceptor, errorInterceptor ]))
    ]
}
