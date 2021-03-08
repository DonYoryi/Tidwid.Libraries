import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Library } from '../models/library';
import { NotificationsService } from '../../../shared/services/notifications.service' 
import { BaseService } from '../../../shared/services/base.service'
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class LibraryService extends BaseService<Library> {


  constructor(notificationsService: NotificationsService,http:HttpClient,spinner: NgxSpinnerService,){
    super(notificationsService,http,spinner)
}


  getLibraryById(id:number):Promise<Library>{
    this.endPoint = "Library/"+id;
    return super.get()
  }

  saveLibrary(library:Library,isEdit:boolean):Promise<any>{
    let message = "Save sussesfull"
    if(isEdit){      
      this.endPoint = "Library/"+library.id;
      return super.put(library,message);
    }else{
      this.endPoint = "Library";
      return super.post(library,message);
    }
  }
  DeleteLibrary(idLibrary: number) {
    this.endPoint = "Library/"+idLibrary;
    return super.delete("Delete sussesfull")
  }

  getAllLibraries():Promise<Library[]>{
    this.endPoint = "library"
    return super.get();
  }
}

