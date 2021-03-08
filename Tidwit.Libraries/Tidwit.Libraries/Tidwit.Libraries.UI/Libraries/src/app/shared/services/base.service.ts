import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment'
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { ErrorTypes } from '../enums/errorTypes';
import { NotificationsService } from './notifications.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export abstract class BaseService<T> {

  urlHost = "";
  endPoint = "";
  options = {}
  storage = window.localStorage;

  constructor(public notificationsService: NotificationsService,private http: HttpClient,private spinner: NgxSpinnerService,) { 
    this.urlHost = environment.urlHost;
    this.options = this.getOptionsHeaders();
   }
   getOptionsHeaders(): {} {
    return{
      headers: new HttpHeaders({
        'Content-Type':'application/json',
        'Accept':'*/*',
      })
    }
  }

  post(entity:any,message?:string): Promise<T>{
    const body = JSON.stringify(entity);
    this.options = this.getOptionsHeaders();
      return this.http.post<T>(this.urlHost+this.endPoint,body,this.options).toPromise()
        .then(data =>this.getDataResult(data,message))
        .catch(error=>this.getErrorResult(error))  
  }

  put(entity:any,message?:string): Promise<T>{
    const body = JSON.stringify(entity);
    this.options = this.getOptionsHeaders();
      return this.http.put<T>(this.urlHost+this.endPoint,body,this.options).toPromise()
        .then(data =>this.getDataResult(data,message))
        .catch(error=>this.getErrorResult(error))  
  }

  get<T>(message?:string): Promise<T>{
    this.options = this.getOptionsHeaders();
      return this.http.get<T>(this.urlHost+this.endPoint,this.options).toPromise()
        .then(data =>this.getDataResult(data,message))
        .catch(error=>this.getErrorResult(error))  
  }

  delete<T>(message?:string): Promise<T>{
    this.options = this.getOptionsHeaders();
      return this.http.delete<T>(this.urlHost+this.endPoint,this.options).toPromise()
        .then(data =>this.getDataResult(data,message))
        .catch(error=>this.getErrorResult(error))  
  }

  getErrorResult(error: HttpErrorResponse | any) {
    if(error instanceof HttpErrorResponse){
        this.notificationsService.showError(error.error?.message,"");
        this.spinner.show()
        switch(error.status){
          case 401:
            this.notificationsService.showError("return back","");
        }
    }
  }

  getDataResult(data: any,message?:string) {
    const request = data;
    if(request.isSuccess){
      if(request.errorType == ErrorTypes.Success){
        if(message){
          this.notificationsService.showSuccess(request.errorMessage,message);
        }
      }
      return request.entity || {};
    }
    else{
      this.notificationsService.showError(request?.errorMessage,"Error");
    }
    
  }
}
