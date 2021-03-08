import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LibraryListComponent } from './library-list.component'
import { LibraryService } from './shared/library.service';
import { LibraryComponent } from './library/library.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from '../../shared/modules/material.module'
import { ImageUploadModule } from 'angular2-image-upload';
import { HttpClientModule } from '@angular/common/http';
import { AngularFireStorageModule } from '@angular/fire/storage';
import { AngularFireModule } from '@angular/fire';
import { environment } from 'src/environments/environment';
const routes: Routes = [
  { path: '', component: LibraryListComponent },
  { path: 'create', component: LibraryComponent },
  { path: 'edit/:id', component: LibraryComponent },

];

@NgModule({
  declarations: [LibraryListComponent,LibraryComponent],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule,
    ImageUploadModule.forRoot(),
    HttpClientModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    AngularFireStorageModule,
  ],
  exports:[RouterModule],
  providers:[LibraryService]
})
export class LibraryModule { }
