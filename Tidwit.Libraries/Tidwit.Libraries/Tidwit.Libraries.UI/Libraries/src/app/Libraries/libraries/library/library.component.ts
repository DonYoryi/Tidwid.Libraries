import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import { UploadMetadata } from 'angular2-image-upload';
import {Observable} from 'rxjs';
import {finalize, map, startWith} from 'rxjs/operators';
import { AngularFireStorage } from '@angular/fire/storage';
import { Library } from '../models/library';
import { LibraryService } from '../shared/library.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NotificationsService } from 'src/app/shared/services/notifications.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.scss']
})
export class LibraryComponent implements OnInit {
  urlImage = "";
  titlePage = "";
  isEdit:boolean = false;
  library:Library = new Library();

  languages:string[]=['spanish','english']
  libraries:string[];
  filteredOptionsLibraries: Observable<string[]>;
  librariesControl = new FormControl({});
  
  dataFile:UploadMetadata = null;

  uploadPercent: Observable<number>;


  customStyle = {
    selectButton: {
      "background-color": "#3f51b5",
      "border-radius": "15px",
      "color": "#FFF"
    },
    clearButton: {
      "background-color": "red",
      "border-radius": "25px",
      "color": "#FFF",
      "margin-left": "10px"
    },
  }
  constructor(private libraryService:LibraryService,
    private storage: AngularFireStorage,
    private router: Router,
    private route: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private notificationsService: NotificationsService,
    ) { }

  ngOnInit() {
    this.spinner.show();
    this.GetLibraries();
    this.GetLibrary();
  }
  GetLibraries() {
    this.libraryService.getAllLibraries().then(dataResult=>{
      this.libraries = dataResult.map(x=>{return x.name.trim()}).filter(x=>x != this.library.name.trim());
      this.GetFilters();
    });
  }
  GetFilters() {
    this.filteredOptionsLibraries = this.librariesControl.valueChanges.pipe(
      startWith(''),
      map(value => this.filter(value))
    );
  }
  GetLibrary() {
    this.route.params.subscribe(
      params => {
        const id = params.id;
        if (id) {
          this.isEdit = true;
          this.getLibraryById(id);
          this.titlePage = 'Editar usuario';
        }
        else {
          this.titlePage = 'Crear usuario';
          this.spinner.hide();
        }
      });
  }
  getLibraryById(id: any) {
    this.libraryService.getLibraryById(id).then(dateResult=>{
      this.library = dateResult;
      this.libraries = this.libraries?.filter(x=>x.trim() != this.library.name.trim());
      this.urlImage = this.library.urlImage;
      this.spinner.hide()
    });
    
  }

  private filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    return this.libraries?.filter(option => option.toLowerCase().indexOf(filterValue) === 0);
  }

  save(){
    let isValid = this.validateInfo();
    if(isValid){
      this.spinner.show()
      if(this.dataFile.file){
        this.saveImg();
      }else{
        this.libraryService.saveLibrary(this.library,this.isEdit).then(x=>{
          this.spinner.hide();
          if(x){
            this.navigationBack();
          }
        });
      }
    }
  }
  saveImg() {
    let idImg = (((1+Math.random())*0x10000)|0).toString(16).substring(1)
    let file = this.dataFile.file
    let filePath = `img/${idImg}`;
    try{
      this.deleteFile();
      const ref = this.storage.ref(filePath);
      const task = this.storage.upload(filePath, file);
      this.uploadPercent = task.percentageChanges();
      task.snapshotChanges()
      .pipe(
        finalize(() => {
          ref.getDownloadURL().subscribe(urlImage => {
            this.library.urlImage = urlImage;
            this.library.filePath = filePath;
            this.dataFile.file = null;
            this.save();
          });
        })
      ).subscribe();
    }
    catch{
      this.notificationsService.showError("","Error uploading the file, try again later")
    }
  }
  deleteFile() {
    if(this.isEdit){
      this.storage.ref(this.library.filePath).delete();
    }
  }
  navigationBack() {
    this.router.navigate([`/`]);
  }
  validateInfo():boolean {
    if(!this.library.name){
      this.notificationsService.showWarning("","name is empty");
      return false;
    }
    if(!this.library.publishDate){
      this.notificationsService.showWarning("","Publish Date is empty");
      return false;
    }
    if(!this.library.language){
      this.notificationsService.showWarning("","Language is empty");
      return false;
    }
    if(this.dataFile.abort && !this.isEdit){
      this.notificationsService.showWarning("","Image is empty");
      return false;
    }
    return true;
  }

  onBeforeUpload = (metadata: UploadMetadata) => {
    let isValid = this.validateFile(metadata);
    if(isValid){
      this.dataFile = metadata;
    }
    return metadata;
  };
  validateFile(metadata: UploadMetadata) {
    if(!metadata.file.type.includes("image")){
      metadata.abort = true;
      this.notificationsService.showWarning("","File extencion not valid");
    }
    if(metadata.file.size > 1000000){
      metadata.abort = true;
      this.notificationsService.showWarning("","File very large");
    }

    return true;
  }
}
