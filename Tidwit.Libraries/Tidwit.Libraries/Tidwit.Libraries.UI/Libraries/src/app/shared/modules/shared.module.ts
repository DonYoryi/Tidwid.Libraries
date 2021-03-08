import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NotificationsService} from '../services/notifications.service'


@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers:[NotificationsService]
})
export class SharedModule { }
