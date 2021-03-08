import { Injectable } from '@angular/core';
import {ToastrService} from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class NotificationsService {

  constructor(private toastr: ToastrService) { }

  showSuccess(message: any, tittle: any) {
    this.toastr.success(message, tittle);
  }

  showError(message: any, tittle: any) {
    this.toastr.error(message, tittle);
  }

  showWarning(message: any, tittle: any) {
    this.toastr.warning(message, tittle);
  }

}
